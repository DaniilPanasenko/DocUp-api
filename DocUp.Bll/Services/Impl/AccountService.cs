using System;
using System.Threading.Tasks;
using AutoMapper;
using DocUp.Bll.Helpers;
using DocUp.Bll.Models;
using DocUp.Dal.Entities;
using DocUp.Dal.Storages;

namespace DocUp.Bll.Services.Impl
{
    public class AccountService : IAccountService
    {
        private readonly IAccountStorage _accountStorage;
        private readonly IClinicStorage _clinicStorage;
        private readonly IPatientStorage _patientStorage;
        private readonly IDoctorStorage _doctorStorage;
        private readonly IMapper _mapper;

        public AccountService(
            IAccountStorage accountStorage,
            IDoctorStorage doctorStorage,
            IPatientStorage patientStorage,
            IClinicStorage clinicStorage,
            IMapper mapper)
        {
            _mapper = mapper;
            _accountStorage = accountStorage;
            _clinicStorage = clinicStorage;
            _doctorStorage = doctorStorage;
            _patientStorage = patientStorage;
        }

        public async Task<int> GetUserIdByAccountIdAsync(int accountId, string role)
        {
            if (role == "clinic")
            {
                return (await _clinicStorage.GetByAccountId(accountId)).Id;
            }
            if (role == "doctor")
            {
                return (await _doctorStorage.GetByAccountId(accountId)).Id;
            }
            if (role == "patient")
            {
                return (await _patientStorage.GetByAccountIdAsync(accountId)).Id;
            }
            else return -1;
        }

        public async Task<ResultCode> AddAdminAsync(AccountModel account)
        {
            account.Role = "admin";
            return await AddAccountAsync(account);
        }

        public async Task<ResultCode> AddClinicAsync(AccountModel account)
        {
            account.Role = "clinic";
            return await AddAccountAsync(account);
        }

        public async Task<ResultCode> AddDoctorAsync(AccountModel account, int clinicId)
        {
            account.Role = "doctor";
            var result = await AddAccountAsync(account);

            if (result != ResultCode.Success)
            {
                return result;
            }

            await _doctorStorage.AddAsync(account.Id, clinicId);
            return ResultCode.Success;
        }

        public async Task<ResultCode> AddPatientAsync(AccountModel account, int doctorId)
        {
            account.Role = "patient";
            var result = await AddAccountAsync(account);

            if (result != ResultCode.Success)
            {
                return result;
            }

            await _patientStorage.AddAsync(account.Id, doctorId);
            return ResultCode.Success;
        }

        public async Task<ResultCode> ChangeBlockedStatusAsync(int accountId)
        {
            var account = await _accountStorage.GetByIdAsync(accountId);
            if (account == null)
            {
                return ResultCode.NotFound;
            }
            account.IsBlocked = !account.IsBlocked;
            await _accountStorage.UpdateAsync(account);
            return ResultCode.Success;
        }

        private async Task<ResultCode> AddAccountAsync(AccountModel account)
        {
            if (await _accountStorage.GetByEmailAsync(account.Email) != null)
            {
                return ResultCode.EmailAlreadyExist;
            }

            if (await _accountStorage.GetByLoginAsync(account.Login) != null)
            {
                return ResultCode.LoginAlreadyExist;
            }

            var accountEntity = _mapper.Map<AccountModel, AccountEntity>(account);

            await _accountStorage.AddAsync(accountEntity);

            return ResultCode.Success;
        }
    }
}
