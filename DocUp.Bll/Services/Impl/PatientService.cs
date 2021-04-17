using System;
using System.Threading.Tasks;
using AutoMapper;
using DocUp.Bll.Helpers;
using DocUp.Bll.Models;
using DocUp.Dal.Entities;
using DocUp.Dal.Storages;

namespace DocUp.Bll.Services.Impl
{
    public class PatientService : IPatientService
    {
        private readonly IPatientStorage _patientStorage;
        private readonly IIlnessStorage _ilnessStorage;
        private readonly IMapper _mapper;

        public PatientService(
            IPatientStorage patientStorage,
            IIlnessStorage ilnessStorage,
            IMapper mapper)
        {
            _mapper = mapper;
            _ilnessStorage = ilnessStorage;
            _patientStorage = patientStorage;
        }

        public async Task<ResultCode> AddIlnessAsync(int patientId, int ilnessId)
        {
            var patient = await _patientStorage.GetByPatientIdAsync(patientId);

            if (patient == null)
            {
                return ResultCode.NotFound;
            }

            if(!await _ilnessStorage.ExistAsync(ilnessId))
            {
                return ResultCode.NotFound;
            }

            if(await _patientStorage.HasIlnessAsync(patientId, ilnessId))
            {
                return ResultCode.UserAlreadyHasIlness;
            }
            await _patientStorage.AddIlnessAsync(patientId, ilnessId);
            return ResultCode.Success;
        }

        public async Task<Result<PatientModel>> GetInfoAsync(int patientId)
        {
            var patient = await _patientStorage.GetByPatientIdAsync(patientId);

            if (patient == null)
            {
                return new Result<PatientModel>(ResultCode.NotFound);
            }

            return new Result<PatientModel>(_mapper.Map<PatientEntity, PatientModel>(patient));
        }

        public async Task<ResultCode> UpdateAsync(PatientModel patient)
        {
            var entity = await _patientStorage.GetByPatientIdAsync(patient.Id);

            if (entity == null)
            {
                return ResultCode.NotFound;
            }

            entity.Name = patient.Name;
            entity.Surname = patient.Surname;
            entity.PhoneNumber = patient.PhoneNumber;
            entity.Age = patient.Age;
            entity.WatcherName = patient.WatcherName;
            entity.WatcherSurname = patient.WatcherSurname;
            entity.WatcherPhoneNumber = patient.WatcherPhoneNumber;
            entity.Address = patient.Address;

            await _patientStorage.UpdateAsync(entity);

            return ResultCode.Success;
        }
    }
}
