using System;
using System.Threading.Tasks;
using DocUp.Dal.Entities;

namespace DocUp.Dal.Storages
{
    public interface IDoctorStorage
    {
        Task AddAsync(int accountId, int clinicId);

        Task<DoctorEntity> GetByAccountIdAsync(int accountId);

        Task<DoctorEntity> GetByDoctorIdAsync(int doctorId);

        Task UpdateAsync(DoctorEntity doctor);
    }
}
