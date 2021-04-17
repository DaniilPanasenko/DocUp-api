using System;
using System.Threading.Tasks;
using DocUp.Dal.Entities;

namespace DocUp.Dal.Storages
{
    public interface IPatientStorage
    {
        Task AddAsync(int accountId, int doctorId);

        Task<PatientEntity> GetByAccountIdAsync(int accountId);

        Task UpdateAsync(PatientEntity patient);

        Task<PatientEntity> GetByPatientIdAsync(int patientId);

        Task AddIlnessAsync(int patientId, int ilnessId);

        Task<bool> HasIlnessAsync(int patientId, int ilnessId);
    }
}
