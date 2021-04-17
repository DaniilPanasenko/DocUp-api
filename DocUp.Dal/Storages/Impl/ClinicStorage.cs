using System;
using System.Threading.Tasks;
using DocUp.Dal.Context;
using DocUp.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocUp.Dal.Storages.Impl
{
    public class ClinicStorage : IClinicStorage
    {
        private readonly DocUpContext _dbContext;

        public ClinicStorage(DocUpContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(int accountId)
        {
            await _dbContext.AddAsync(new ClinicEntity { AccountId = accountId });
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ClinicEntity> GetByAccountId(int accountId)
        {
            return await _dbContext.Clinics.FirstOrDefaultAsync(x => x.AccountId == accountId);
        }

        public async Task<ClinicEntity> GetByClinicId(int clinicId)
        {
            return await _dbContext.Clinics
                .Include(x=>x.Account)
                .Include(x=>x.Doctors)
                .FirstOrDefaultAsync(x => x.Id == clinicId);
        }

        public async Task UpdateAsync(ClinicEntity clinic)
        {
            _dbContext.Update(clinic);
            await _dbContext.SaveChangesAsync();
        }
    }
}
