using AuthServer.API.Application.Features.Users.Commands.EditEmail;
using AuthServer.API.Application.Features.Users.Commands.EditPassword;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;

namespace AuthServer.API.Application.Features.Auths.Profiles
{
    public class AuthMapping:Profile
    {
        public AuthMapping()
        {
            CreateMap<User, UserForUpdatePasswordDto>().ReverseMap();
            CreateMap<User, EditPasswordCommand>().ReverseMap();

            CreateMap<User, UserForUpdateEmailDto>().ReverseMap();
            CreateMap<User, EditEmailCommand>().ReverseMap();
            CreateMap<EditEmailCommand, UserForUpdateEmailDto>().ReverseMap();
        }
    }
}
