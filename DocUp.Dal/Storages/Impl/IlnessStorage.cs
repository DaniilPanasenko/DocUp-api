using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocUp.Dal.Entities;

namespace DocUp.Dal.Storages.Impl
{
    public class IlnessStorage : IIlnessStorage
    {
        public IlnessStorage()
        {
        }

        public Task AddAsync(IlnessEntity ilness)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(int ilnessId)
        {
            throw new NotImplementedException();
        }

        public Task<List<IlnessEntity>> GetIlnessListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
