using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocUp.Dal.Context;
using DocUp.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocUp.Dal.Storages.Impl
{
    public class AccountStorage : IAccountStorage
    {
        private readonly DocUpContext _dbContext;

        public AccountStorage(DocUpContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(AccountEntity account)
        {
            await _dbContext.Accounts.AddAsync(account);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<AccountEntity> GetByLoginAsync(string login)
        {
            return await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<AccountEntity> GetByEmailAsync(string email)
        {
            return await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<AccountEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Id==id);
        }

        public async Task UpdateAsync(AccountEntity account)
        {
            _dbContext.Update(account);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<AccountEntity>> GetAllAsync()
        {
            return await _dbContext.Accounts.OrderBy(x => x.Id).ToListAsync();
        }
    }
}
