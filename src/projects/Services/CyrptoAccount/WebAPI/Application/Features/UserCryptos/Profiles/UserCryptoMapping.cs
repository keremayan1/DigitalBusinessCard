using AutoMapper;
using Core.Persistance.Paging;
using WebAPI.Application.Features.UserCryptos.Commands.Add;
using WebAPI.Application.Features.UserCryptos.Commands.Delete;
using WebAPI.Application.Features.UserCryptos.Commands.Update;
using WebAPI.Application.Features.UserCryptos.DTOs;
using WebAPI.Application.Features.UserCryptos.Models;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Features.UserCryptos.Profiles
{
    public class UserCryptoMapping:Profile
    {
        public UserCryptoMapping()
        {
            CreateMap<UserCyrpto, CreatedUserCryptoDto>().ReverseMap();
            CreateMap<UserCyrpto, CreateUserCryptoCommand>().ReverseMap();

            CreateMap<UserCyrpto, DeleteUserCryptoCommand>().ReverseMap();
            CreateMap<UserCyrpto, DeletedUserCryptoDto>().ReverseMap();

            CreateMap<UserCyrpto, UpdateUserCryptoCommand>().ReverseMap();
            CreateMap<UserCyrpto, UpdatedUserCryptoDto>().ReverseMap();

            CreateMap<IPaginate<UserCyrpto>, UserCryptoModel>().ReverseMap();
            CreateMap<UserCyrpto, GetListUserCryptoDto>().ForMember(x=>x.CyrptoUrl,opt=>opt.MapFrom(x=>x.CryptoUrl))
                                                         .ForMember(x=>x.CryptoName,opt=>opt.MapFrom(x=>x.Crypto.CryptoName))
                                                         .ReverseMap();

        }
    }
}
