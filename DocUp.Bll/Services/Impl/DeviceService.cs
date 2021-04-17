﻿using System;
using System.Threading.Tasks;
using AutoMapper;
using DocUp.Bll.Helpers;
using DocUp.Bll.Models;
using DocUp.Dal.Entities;
using DocUp.Dal.Storages;

namespace DocUp.Bll.Services.Impl
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceStorage _deviceStorage;
        private readonly IIlnessStorage _ilnessStorage;
        private readonly IMapper _mapper;

        public DeviceService(
            IDeviceStorage deviceStorage,
            IIlnessStorage ilnessStorage,
            IMapper mapper)
        {
            _mapper = mapper;
            _deviceStorage = deviceStorage;
            _ilnessStorage = ilnessStorage;
        }

        public async  Task<ResultCode> AddAsync(DeviceModel device)
        {
            if (! await _ilnessStorage.ExistAsync(device.IlnessId))
            {
                return ResultCode.NotFound;
            }
            if(await _deviceStorage.ExistAsync(device.Seria))
            {
                return ResultCode.DeviceSeriaAlreadyExst;
            }
            var entity = _mapper.Map<DeviceModel, DeviceEntity>(device);
            await _deviceStorage.AddAsync(entity);
            return ResultCode.Success;
        }

        public async Task<ResultCode> AddDataAsync(DeviceDataModel data)
        {
            if (!await _deviceStorage.ExistAsync(data.Seria))
            {
                return ResultCode.NotFound;
            }

            var deviceId = await _deviceStorage.GetIdBySeriaAsync(data.Seria);
            data.DeviceId = deviceId;

            var entity = _mapper.Map<DeviceDataModel, ReadingEntity>(data);

            await _deviceStorage.AddReadingAsync(entity);

            return ResultCode.Success;
        }

        public async Task<ResultCode> ConnectToUserAsync(int userId, int seria)
        {
            if (!await _deviceStorage.ExistAsync(seria))
            {
                return ResultCode.NotFound;
            }
            if (await _deviceStorage.HaveUserAsync(seria))
            {
                return ResultCode.DeviceAlreadyHaveUser;
            }
            if (!await _deviceStorage.PatientHasIlnessByDeviceSeriaAsync(userId, seria))
            {
                return ResultCode.NotFound;
            }
            await _deviceStorage.AddDeviceToUserAsync(userId, seria);
            return ResultCode.Success;
        }
    }
}
