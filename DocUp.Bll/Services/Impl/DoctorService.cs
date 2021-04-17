using System;
using System.Threading.Tasks;
using AutoMapper;
using DocUp.Bll.Helpers;
using DocUp.Bll.Models;
using DocUp.Dal.Entities;
using DocUp.Dal.Storages;

namespace DocUp.Bll.Services.Impl
{
    public class DoctorService : IDoctorService
    {
        private readonly IAccountStorage _accountStorage;
        private readonly IClinicStorage _clinicStorage;
        private readonly IPatientStorage _patientStorage;
        private readonly IDoctorStorage _doctorStorage;
        private readonly IMapper _mapper;

        public DoctorService(
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

        public async Task<Result<DoctorModel>> GetInfoAsync(int doctorId)
        {
            var doctor = await _doctorStorage.GetByDoctorIdAsync(doctorId);

            if (doctor == null)
            {
                return new Result<DoctorModel>(ResultCode.NotFound);
            }

            return new Result<DoctorModel>(_mapper.Map<DoctorEntity, DoctorModel>(doctor));

        }

        public async Task<ResultCode> UpdateAsync(DoctorModel doctor)
        {
            var entity = await _doctorStorage.GetByDoctorIdAsync(doctor.Id);

            if (entity == null)
            {
                return ResultCode.NotFound;
            }

            entity.Name = doctor.Name;
            entity.Surname = doctor.Surname;
            entity.PhoneNumber = doctor.PhoneNumber;
            entity.Position = doctor.Position;

            await _doctorStorage.UpdateAsync(entity);

            return ResultCode.Success;
        }
    }
}
