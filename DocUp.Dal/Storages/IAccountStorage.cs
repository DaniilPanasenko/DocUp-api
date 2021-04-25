using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocUp.Dal.Entities;

namespace DocUp.Dal.Storages
{
    public interface IAccountStorage
    {
        Task AddAsync(AccountEntity account);

        Task<AccountEntity> GetByLoginAsync(string login);

        Task<AccountEntity> GetByEmailAsync(string email);

        Task<AccountEntity> GetByIdAsync(int id);

        Task UpdateAsync(AccountEntity account);

        Task<List<AccountEntity>> GetAllAsync();
    }
}
