using System;
using System.Threading.Tasks;
using DocUp.Dal.Entities;

namespace DocUp.Dal.Storages.Impl
{
    public class DeviceStorage : IDeviceStorage
    {
        public DeviceStorage()
        {
        }

        public Task AddAsync(DeviceEntity deice)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(int deviceSeria)
        {
            throw new NotImplementedException();
        }
    }
}
