using System;
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

        public async Task<AccountEntity> GetByLoginAsync(string login)
        {
            return await _dbContext.Accounts
                .Where(account => account.Login == login)
                .FirstOrDefaultAsync();
        }
    }
}
