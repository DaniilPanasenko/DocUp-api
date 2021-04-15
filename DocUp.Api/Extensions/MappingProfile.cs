using System;
using AutoMapper;
using DocUp.Api.Contracts.Dtos;
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


            CreateMap<AccountDto, AccountModel>()
                .ForMember(x => x.PasswordHash, y => y
                      .MapFrom(z => PasswordHash
                            .CreateHash(z.Password)));
            CreateMap<IlnessDto, IlnessModel>().ReverseMap();
            CreateMap<DeviceDto, DeviceModel>().ReverseMap();
        }
    }
}
