using System;
using System.Threading.Tasks;
using DocUp.Dal.Entities;

namespace DocUp.Dal.Storages
{
    public interface IClinicStorage
    {
        Task AddAsync(int accountId);

        Task<ClinicEntity> GetByAccountId(int accountId);
    }
}
