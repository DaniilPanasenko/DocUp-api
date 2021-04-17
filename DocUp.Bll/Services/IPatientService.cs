using System;
using System.Threading.Tasks;
using DocUp.Bll.Helpers;
using DocUp.Bll.Models;

namespace DocUp.Bll.Services
{
    public interface IPatientService
    {
        Task<Result<PatientModel>> GetInfoAsync(int patientId);

        Task<ResultCode> UpdateAsync(PatientModel patient);

        Task<ResultCode> AddIlnessAsync(int patientId, int ilnessId);
    }
}
