using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocUp.Dal.Entities;

namespace DocUp.Dal.Storages
{
    public interface IIlnessStorage
    {
        Task AddAsync(IlnessEntity ilness);

        Task<List<IlnessEntity>> GetIlnessListAsync();

        Task<bool> ExistAsync(int ilnessId);
    }
}
