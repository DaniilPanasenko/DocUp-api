﻿using System;
using System.Threading.Tasks;
using DocUp.Bll.Helpers;
using DocUp.Bll.Models;

namespace DocUp.Bll.Services
{
    public interface IDeviceService
    {
        Task<ResultCode> AddAsync(DeviceModel device);
    }
}
