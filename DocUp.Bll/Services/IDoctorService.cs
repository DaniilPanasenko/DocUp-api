using System;
using System.Threading.Tasks;
using DocUp.Bll.Helpers;
using DocUp.Bll.Models;

namespace DocUp.Bll.Services
{
    public interface IDoctorService
    {
        Task<Result<DoctorModel>> GetInfoAsync(int doctorId);

        Task<ResultCode> UpdateAsync(DoctorModel doctor);
    }
}
