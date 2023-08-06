using AuthServer.API.Application.Features.Auths.Commands.EditPassword;
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
        }
    }
}
