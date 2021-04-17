using System;
using AutoMapper;
using DocUp.Api.Contracts.Dtos;
using DocUp.Api.Contracts.ViewModels;
using DocUp.Bll.Helpers;
using DocUp.Bll.Models;
using DocUp.Dal.Entities;

namespace DocUp.Api.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountEntity, AccountModel>().ReverseMap();
            CreateMap<IlnessEntity, IlnessModel>().ReverseMap();
            CreateMap<DeviceEntity, DeviceModel>().ReverseMap();
            CreateMap<ReadingEntity, DeviceDataModel>().ReverseMap();
            CreateMap<ClinicEntity, ClinicModel>()
                .ForMember(x => x.DoctorCount, y => y
                      .MapFrom(z => z.Doctors.Count))
                .ForMember(x => x.Email, y => y
                      .MapFrom(z => z.Account.Email))
                .ForMember(x => x.Login, y => y
                      .MapFrom(z => z.Account.Login));
            CreateMap<DoctorEntity, DoctorModel>()
                .ForMember(x => x.PatientCount, y => y
                      .MapFrom(z => z.Patients.Count))
                .ForMember(x => x.Email, y => y
                      .MapFrom(z => z.Account.Email))
                .ForMember(x => x.Login, y => y
                      .MapFrom(z => z.Account.Login))
                .ForMember(x => x.ClinicName, y => y
                      .MapFrom(z => z.Clinic.Name));
            CreateMap<PatientEntity, PatientModel>()
                .ForMember(x => x.ClinicName, y => y
                      .MapFrom(z => z.Doctor.Clinic.Name))
                .ForMember(x => x.Email, y => y
                      .MapFrom(z => z.Account.Email))
                .ForMember(x => x.Login, y => y
                      .MapFrom(z => z.Account.Login))
                .ForMember(x => x.DoctorName, y => y
                      .MapFrom(z => z.Doctor.Name));



            CreateMap<AccountDto, AccountModel>()
                .ForMember(x => x.PasswordHash, y => y
                      .MapFrom(z => PasswordHash
                            .CreateHash(z.Password)));
            CreateMap<IlnessDto, IlnessModel>();
            CreateMap<DeviceDto, DeviceModel>();
            CreateMap<DeviceDataDto, DeviceDataModel>();
            CreateMap<ClinicDto, ClinicModel>();
            CreateMap<DoctorDto, DoctorModel>();
            CreateMap<PatientDto, PatientModel>();


            CreateMap<ClinicModel, ClinicVm>();
            CreateMap<DoctorModel, DoctorVm>();
            CreateMap<PatientModel, PatientVm>();
            CreateMap<NotificationModel, NotificationVm>();
        }
    }
}
