using System;
using System.Threading.Tasks;
using DocUp.Bll.Helpers;
using DocUp.Bll.Models;

namespace DocUp.Bll.Services
{
    public interface IClinicService
    {
        Task<Result<ClinicModel>> GetInfoAsync(int clinicId);

        Task<ResultCode> UpdateAsync(ClinicModel clinic);
    }
}
