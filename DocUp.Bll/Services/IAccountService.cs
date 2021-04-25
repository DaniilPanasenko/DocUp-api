using System.Collections.Generic;
using System.Threading.Tasks;
using DocUp.Bll.Helpers;
using DocUp.Bll.Models;

namespace DocUp.Bll.Services
{
    public interface IAccountService
    {
        Task<int> GetUserIdByAccountIdAsync(int accountId, string role);

        Task<ResultCode> AddAdminAsync(AccountModel account);

        Task<ResultCode> AddClinicAsync(AccountModel account);

        Task<ResultCode> AddDoctorAsync(AccountModel account, int clinicId);

        Task<ResultCode> AddPatientAsync(AccountModel account, int doctorId);

        Task<ResultCode> AddOperatorAsync(AccountModel account);

        Task<ResultCode> ChangeBlockedStatusAsync(int accountId);

        Task<List<AccountModel>> GetAllAccountsAsync();
    }
}
