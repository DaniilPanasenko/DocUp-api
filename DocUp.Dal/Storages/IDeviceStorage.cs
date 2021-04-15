using System;
using System.Threading.Tasks;
using DocUp.Dal.Entities;

namespace DocUp.Dal.Storages
{
    public interface IDeviceStorage
    {
        Task AddAsync(DeviceEntity deice);

        Task<bool> ExistAsync(int deviceSeria);
    }
}
