using Application.Features.TelephoneNumbers.Commands.Add;
using Application.Features.TelephoneNumbers.Commands.Delete;
using Application.Features.TelephoneNumbers.Commands.Update;
using Application.Features.TelephoneNumbers.DTOs;
using Application.Features.TelephoneNumbers.Models;
using AutoMapper;
using Core.Persistance.Paging;
using Domain.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TelephoneNumbers.Profiles
{
    public class UserTelephoneNumberMapping:Profile
    {
        public UserTelephoneNumberMapping()
        {
            CreateMap<UserTelephoneNumber, CreatedUserTelephoneNumberDto>().ReverseMap();
            CreateMap<UserTelephoneNumber, CreateUserTelephoneNumberCommand>().ReverseMap();

            CreateMap<UserTelephoneNumber, DeletedUserTelephoneNumberDto>().ReverseMap();
            CreateMap<UserTelephoneNumber, DeleteUserTelephoneNumberCommand>().ReverseMap();

            CreateMap<UserTelephoneNumber, UpdatedUserTelephoneNumberDto>().ReverseMap();
            CreateMap<UserTelephoneNumber, UpdateUserTelephoneNumberCommand>().ReverseMap();

            CreateMap<UserTelephoneNumber, GetByUserTelephoneNumberDto>().ForMember(x=>x.TelephoneType,opt=>opt.MapFrom(x=>x.UserTelephoneType.TelephoneType))
                .ForMember(x=>x.TelephoneCountryDialCode,opt=>opt.MapFrom(x=>x.UserTelephoneCountry.CountryDialCode))
                .ForMember(x=>x.TelephoneNumber,opt=>opt.MapFrom(x=>x.UserTelephoneCountry.CountryDialCode+ " "+x.TelephoneNumber)).ReverseMap();
            CreateMap<IPaginate<UserTelephoneNumber>, UserTelephoneNumberModel>().ReverseMap();

        }
    }
}
