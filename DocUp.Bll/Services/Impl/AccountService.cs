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
        private readonly IMapper _mapper;

        public AccountService(
            IAccountStorage accountStorage,
            IMapper mapper)
        {
            _mapper = mapper;
            _accountStorage = accountStorage;
        }

        public async Task<ResultCode> AddAccountAsync(AccountModel account)
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

            await _accountStorage.AddAccountAsync(accountEntity);

            return ResultCode.Success;
        }
    }
}
