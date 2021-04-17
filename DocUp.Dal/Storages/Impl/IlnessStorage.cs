using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocUp.Dal.Context;
using DocUp.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocUp.Dal.Storages.Impl
{
    public class IlnessStorage : IIlnessStorage
    {
        private readonly DocUpContext _dbContext;

        public IlnessStorage(DocUpContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(IlnessEntity ilness)
        {
            await _dbContext.AddAsync(ilness);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(int ilnessId)
        {
            return await _dbContext.Ilnesses.AnyAsync(x => x.Id == ilnessId);
        }

        public async Task<List<IlnessEntity>> GetIlnessListAsync()
        {
            return await _dbContext.Ilnesses.ToListAsync();
        }
    }
}
