using System;
using System.Threading.Tasks;
using DocUp.Dal.Entities;

namespace DocUp.Dal.Storages.Impl
{
    public class ClinicStorage : IClinicStorage
    {
        public ClinicStorage()
        {
        }

        public Task AddAsync(int accountId)
        {
            throw new NotImplementedException();
        }

        public Task<ClinicEntity> GetByAccountId(int accountId)
        {
            throw new NotImplementedException();
        }
    }
}
