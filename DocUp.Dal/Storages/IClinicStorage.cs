using System;
using System.Threading.Tasks;
using DocUp.Dal.Entities;

namespace DocUp.Dal.Storages
{
    public interface IClinicStorage
    {
        Task AddAsync(int accountId);

        Task<ClinicEntity> GetByAccountIdAsync(int accountId);

        Task<ClinicEntity> GetByClinicIdAsync(int clinicId);

        Task UpdateAsync(ClinicEntity clinic);
    }
}
