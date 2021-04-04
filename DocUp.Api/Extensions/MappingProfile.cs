using System;
using AutoMapper;
using DocUp.Bll.Models;
using DocUp.Dal.Entities;

namespace DocUp.Api.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AccountEntity, AccountModel>().ReverseMap();
        }
    }
}
