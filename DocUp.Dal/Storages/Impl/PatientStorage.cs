using System;
using System.Threading.Tasks;
using DocUp.Dal.Entities;

namespace DocUp.Dal.Storages.Impl
{
    public class PatientStorage : IPatientStorage
    {
        public PatientStorage()
        {
        }

        public Task AddAsync(int accountId, int doctorId)
        {
            throw new NotImplementedException();
        }

        public Task<PatientEntity> GetByAccountId(int accountId)
        {
            throw new NotImplementedException();
        }
    }
}
