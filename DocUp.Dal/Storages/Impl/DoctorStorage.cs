using System;
using System.Threading.Tasks;
using DocUp.Dal.Entities;

namespace DocUp.Dal.Storages.Impl
{
    public class DoctorStorage : IDoctorStorage
    {
        public DoctorStorage()
        {
        }

        public Task AddAsync(int accountId, int clinicId)
        {
            throw new NotImplementedException();
        }

        public Task<DoctorEntity> GetByAccountId(int accountId)
        {
            throw new NotImplementedException();
        }
    }
}
