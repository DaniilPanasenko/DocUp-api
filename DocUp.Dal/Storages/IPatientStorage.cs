using System;
using System.Threading.Tasks;
using DocUp.Dal.Entities;

namespace DocUp.Dal.Storages
{
    public interface IPatientStorage
    {
        Task AddAsync(int accountId, int doctorId);

        Task<PatientEntity> GetByAccountId(int accountId);
    }
}
