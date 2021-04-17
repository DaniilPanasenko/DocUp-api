using System;
using System.Threading.Tasks;
using DocUp.Dal.Context;
using DocUp.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocUp.Dal.Storages.Impl
{
    public class PatientStorage : IPatientStorage
    {
        private readonly DocUpContext _dbContext;

        public PatientStorage(DocUpContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(int accountId, int doctorId)
        {
            await _dbContext.AddAsync(new PatientEntity { AccountId = accountId, DoctorId = doctorId });
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddIlnessAsync(int patientId, int ilnessId)
        {
            await _dbContext.AddAsync(new PatientIlnessEntity { PatientId = patientId, IlnessId = ilnessId });
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PatientEntity> GetByAccountIdAsync(int accountId)
        {
            return await _dbContext.Patients.FirstOrDefaultAsync(x => x.AccountId == accountId);
        }

        public async Task<PatientEntity> GetByPatientIdAsync(int patientId)
        {
            return await _dbContext.Patients
                .Include(x => x.Account)
                .Include(x => x.Doctor)
                .ThenInclude(x => x.Clinic)
                .FirstOrDefaultAsync(x => x.Id == patientId);
        }

        public async Task<bool> HasIlnessAsync(int patientId, int ilnessId)
        {
            return await _dbContext.PatientIlnesses.AnyAsync(x => x.PatientId == patientId && x.IlnessId == ilnessId);
        }

        public async Task UpdateAsync(PatientEntity patient)
        {
            _dbContext.Update(patient);
            await _dbContext.SaveChangesAsync();
        }
    }
}
