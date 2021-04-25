using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocUp.Dal.Context;
using DocUp.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocUp.Dal.Storages.Impl
{
    public class DoctorStorage : IDoctorStorage
    {
        private readonly DocUpContext _dbContext;

        public DoctorStorage(DocUpContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(int accountId, int clinicId)
        {
            await _dbContext.AddAsync(new DoctorEntity { AccountId = accountId, ClinicId = clinicId });
            await _dbContext.SaveChangesAsync();
        }

        public async Task<DoctorEntity> GetByAccountIdAsync(int accountId)
        {
            return await _dbContext.Doctors.FirstOrDefaultAsync(x => x.AccountId == accountId);
        }

        public async Task<DoctorEntity> GetByDoctorIdAsync(int doctorId)
        {
            return await _dbContext.Doctors
                .Include(x => x.Account)
                .Include(x => x.Patients)
                .Include(x=>x.Clinic)
                .FirstOrDefaultAsync(x => x.Id == doctorId);
        }

        public Task<List<DoctorEntity>> GetListByClinicId(int clinicId)
        {
           return _dbContext.Doctors
                .Include(x => x.Account)
                .Include(x => x.Patients)
                .Include(x => x.Clinic)
                .Where(x=>x.ClinicId==clinicId)
                .ToListAsync();
        }

        public async Task UpdateAsync(DoctorEntity doctor)
        {
            _dbContext.Update(doctor);
            await _dbContext.SaveChangesAsync();
        }
    }
}
