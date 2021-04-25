using System;
using System.Collections.Generic;
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
                return (await _clinicStorage.GetByAccountIdAsync(accountId)).Id;
            }
            if (role == "doctor")
            {
                return (await _doctorStorage.GetByAccountIdAsync(accountId)).Id;
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
            return (await AddAccountAsync(account)).Code;
        }

        public async Task<ResultCode> AddOperatorAsync(AccountModel account)
        {
            account.Role = "operator";
            return (await AddAccountAsync(account)).Code;
        }

        public async Task<ResultCode> AddClinicAsync(AccountModel account)
        {
            account.Role = "clinic";
            var result = await AddAccountAsync(account);

            if (result.Code != ResultCode.Success)
            {
                return result.Code;
            }

            await _clinicStorage.AddAsync(result.Value.Id);
            return ResultCode.Success;
        }

        public async Task<ResultCode> AddDoctorAsync(AccountModel account, int clinicId)
        {
            account.Role = "doctor";
            var result = await AddAccountAsync(account);

            if (result.Code != ResultCode.Success)
            {
                return result.Code;
            }

            await _doctorStorage.AddAsync(result.Value.Id, clinicId);
            return ResultCode.Success;
        }

        public async Task<ResultCode> AddPatientAsync(AccountModel account, int doctorId)
        {
            account.Role = "patient";
            var result = await AddAccountAsync(account);

            if (result.Code != ResultCode.Success)
            {
                return result.Code;
            }

            await _patientStorage.AddAsync(result.Value.Id, doctorId);
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

        private async Task<Result<AccountEntity>> AddAccountAsync(AccountModel account)
        {
            if (await _accountStorage.GetByEmailAsync(account.Email) != null)
            {
                return new Result<AccountEntity>(ResultCode.EmailAlreadyExist);
            }

            if (await _accountStorage.GetByLoginAsync(account.Login) != null)
            {
                return new Result<AccountEntity>(ResultCode.LoginAlreadyExist);
            }

            var accountEntity = _mapper.Map<AccountModel, AccountEntity>(account);

            await _accountStorage.AddAsync(accountEntity);

            return new Result<AccountEntity>(accountEntity);
        }

        public async Task<List<AccountModel>> GetAllAccountsAsync()
        {
            var users = await _accountStorage.GetAllAsync();
            return _mapper.Map<List<AccountEntity>, List<AccountModel>>(users);
        }
    }
}
