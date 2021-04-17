using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DocUp.Dal.Entities;

namespace DocUp.Dal.Storages
{
    public interface IDeviceStorage
    {
        Task AddAsync(DeviceEntity deice);

        Task<bool> ExistAsync(int deviceSeria);

        Task AddDeviceToUserAsync(int userId, int seria);

        Task<bool> HaveUserAsync(int seria);

        Task<int> GetIdBySeriaAsync(int seria);

        Task AddReadingAsync(ReadingEntity reading);

        Task<List<ReadingEntity>> GetDataDueTimeAsync(DateTimeOffset time);

        Task<bool> PatientHasIlnessByDeviceSeriaAsync(int userId, int seria);
    }
}
