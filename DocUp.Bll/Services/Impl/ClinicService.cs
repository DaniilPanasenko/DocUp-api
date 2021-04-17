using System;
using System.Threading.Tasks;
using AutoMapper;
using DocUp.Bll.Helpers;
using DocUp.Bll.Models;
using DocUp.Dal.Entities;
using DocUp.Dal.Storages;

namespace DocUp.Bll.Services.Impl
{
    public class ClinicService : IClinicService
    {
        private readonly IAccountStorage _accountStorage;
        private readonly IClinicStorage _clinicStorage;
        private readonly IPatientStorage _patientStorage;
        private readonly IDoctorStorage _doctorStorage;
        private readonly IMapper _mapper;

        public ClinicService(
            IAccountStorage accountStorage,
            IDoctorStorage doctorStorage,
            IPatientStorage patientStorage,
            IClinicStorage clinicStorage,
            IMapper mapper)
        {
            _mapper = mapper;
            _accountStorage = accountStorage;
            _clinicStorage = clinicStorage;
            _doctorStorage = doctorStorage;
            _patientStorage = patientStorage;
        }

        public async Task<Result<ClinicModel>> GetInfoAsync(int clinicId)
        {
            var clinic = await _clinicStorage.GetByClinicIdAsync(clinicId);

            if (clinic == null)
            {
                return new Result<ClinicModel>(ResultCode.NotFound);
            }

            return new Result<ClinicModel>(_mapper.Map<ClinicEntity, ClinicModel>(clinic));

        }

        public async Task<ResultCode> UpdateAsync(ClinicModel clinic)
        {
            var entity = await _clinicStorage.GetByClinicIdAsync(clinic.Id);

            if (entity == null)
            {
                return ResultCode.NotFound;
            }

            entity.Name = clinic.Name;
            entity.Place = clinic.Place;
            entity.PhoneNumber = clinic.PhoneNumber;

            await _clinicStorage.UpdateAsync(entity);

            return ResultCode.Success;
        }
    }
}
