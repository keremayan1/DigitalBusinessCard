using AutoMapper;
using Core.Persistance.Paging;
using IBANAccount.API.Application.Features.UserIbans.Commands.Add;
using IBANAccount.API.Application.Features.UserIbans.Commands.Delete;
using IBANAccount.API.Application.Features.UserIbans.Commands.Update;
using IBANAccount.API.Application.Features.UserIbans.DTOs;
using IBANAccount.API.Application.Features.UserIbans.Models;
using IBANAccount.API.Domain.Entities;

namespace IBANAccount.API.Application.Features.UserIbans.Profiles
{
    public class UserIbanMapping:Profile
    {
        public UserIbanMapping()
        {
            CreateMap<UserIban, CreatedUserIbanDto>().ReverseMap();
            CreateMap<UserIban, CreateUserIbanCommand>().ReverseMap();

            CreateMap<UserIban, DeleteUserIbanCommand>().ReverseMap();
            CreateMap<UserIban, DeletedUserIbanDto>().ReverseMap();
            
            CreateMap<UserIban, UpdatedUserIbanDto>().ReverseMap();
            CreateMap<UserIban, UpdateUserIbanCommand>().ReverseMap();

            CreateMap<UserIban, GetUserIbanDto>().ForMember(x => x.IbanNameAndNumber, opt =>  opt.MapFrom(x=>x.Iban.Code+x.IbanNumber)).ReverseMap();
            CreateMap<IPaginate<UserIban>, UserIbanModel>().ReverseMap();
        }
    }
}
