using System;
using System.Threading.Tasks;
using DocUp.Dal.Entities;

namespace DocUp.Dal.Storages
{
    public interface IAccountStorage
    {
        Task AddAccountAsync(AccountEntity account);

        Task<AccountEntity> GetByLoginAsync(string login);

        Task<AccountEntity> GetByEmailAsync(string email);
    }
}
