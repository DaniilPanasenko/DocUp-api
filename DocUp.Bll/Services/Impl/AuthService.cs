using System;
using System.Threading.Tasks;
using AutoMapper;
using DocUp.Bll.Helpers;
using DocUp.Bll.Models;
using DocUp.Dal.Entities;
using DocUp.Dal.Storages;

namespace DocUp.Bll.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly IAccountStorage _accountStorage;
        private readonly IMapper _mapper;

        public AuthService(
            IAccountStorage accountStorage,
            IMapper mapper)
        {
            _mapper = mapper;
            _accountStorage = accountStorage;
        }

        public async Task<Result<AccountModel>> LoginAsync(string login, string password)
        {
            var user = await _accountStorage.GetByLoginAsync(login);

            if (user == null)
            {
                return new Result<AccountModel>(ResultCode.InvalidLogin);
            }

            var passwordIsValid = PasswordHash.ValidatePassword(password, user.PasswordHash);

            return !passwordIsValid
                ? new Result<AccountModel>(ResultCode.InvalidPassword)
                : new Result<AccountModel>(_mapper.Map<AccountEntity, AccountModel>(user));
        }
    }
}
