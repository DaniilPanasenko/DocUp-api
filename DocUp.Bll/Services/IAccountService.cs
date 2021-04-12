using System.Threading.Tasks;
using DocUp.Bll.Helpers;
using DocUp.Bll.Models;

namespace DocUp.Bll.Services
{
    public interface IAccountService
    {
        public Task<ResultCode> AddAccountAsync(AccountModel account);
    }
}
