using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DocUp.Dal.Context;
using DocUp.Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocUp.Dal.Storages.Impl
{
    public class DeviceStorage : IDeviceStorage
    {
        private readonly DocUpContext _dbContext;

        public DeviceStorage(DocUpContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(DeviceEntity device)
        {
            await _dbContext.AddAsync(device);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddDeviceToUserAsync(int userId, int seria)
        {
            var device = await _dbContext.Devices.FirstAsync(x => x.Seria == seria);
            var patientIlness = await _dbContext.PatientIlnesses
                .FirstAsync(x => x.PatientId == userId && x.IlnessId == device.IlnessId);
            device.PatientIlnessId = patientIlness.Id;
            patientIlness.DeviceId = device.Id;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> PatientHasIlnessByDeviceSeriaAsync(int userId, int seria)
        {
            var device = await _dbContext.Devices.FirstAsync(x => x.Seria == seria);
            return await _dbContext.PatientIlnesses.AnyAsync(x => x.PatientId == userId && x.IlnessId == device.IlnessId);
        }

        public async Task AddReadingAsync(ReadingEntity reading)
        {
            await _dbContext.AddAsync(reading);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<bool> ExistAsync(int deviceSeria)
        {
            return await _dbContext.Devices.AnyAsync(x => x.Seria == deviceSeria);
        }

        public async Task<List<ReadingEntity>> GetDataDueTimeAsync(DateTimeOffset time)
        {
            return await _dbContext.Readings
                .Include(x => x.Device)
                .ThenInclude(x => x.PatientIlness)
                .ThenInclude(x => x.Patient)
                .ThenInclude(x => x.Doctor)
                .ThenInclude(x => x.Clinic)
                .Include(x => x.Device)
                .ThenInclude(x => x.Ilness)
                .Where(x => x.DateTime > time)
                .ToListAsync();
        }

        public async Task<int> GetIdBySeriaAsync(int seria)
        {
            return (await _dbContext.Devices.FirstAsync(x => x.Seria == seria)).Id;
        }

        public async Task<bool> HaveUserAsync(int seria)
        {
            return (await _dbContext.Devices.FirstAsync(x => x.Seria == seria)).PatientIlnessId != null;
        }
    }
}
