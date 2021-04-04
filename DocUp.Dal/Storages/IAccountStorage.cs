using System;
using System.Threading.Tasks;
using DocUp.Dal.Entities;

namespace DocUp.Dal.Storages
{
    public interface IAccountStorage
    {
        Task<AccountEntity> GetByLoginAsync(string login);
    }
}
