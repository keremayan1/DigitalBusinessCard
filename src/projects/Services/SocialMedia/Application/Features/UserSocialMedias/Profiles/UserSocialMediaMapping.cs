using Application.Features.UserSocialMedias.Commands.Add;
using Application.Features.UserSocialMedias.Commands.Delete;
using Application.Features.UserSocialMedias.Commands.Update;
using Application.Features.UserSocialMedias.DTOs;
using Application.Features.UserSocialMedias.Models;
using AutoMapper;
using Core.Persistance.Paging;
using Domain.Entities.Concrete;

namespace Application.Features.UserSocialMedias.Profiles
{
    public class UserSocialMediaMapping:Profile
    {
        public UserSocialMediaMapping()
        {
            CreateMap<UserSocialMedia, CreatedUserSocialMediaDto>().ReverseMap();
            CreateMap<UserSocialMedia, CreateUserSocialMediaCommand>().ReverseMap();

            CreateMap<UserSocialMedia, UpdatedUserSocialMediaDto>().ReverseMap();
            CreateMap<UserSocialMedia, UpdateUserSocialMediaCommand>().ReverseMap();

            CreateMap<UserSocialMedia, DeletedUserSocialMediaDto>().ReverseMap();
            CreateMap<UserSocialMedia, DeleteUserSocialMediaCommand>().ReverseMap();


            CreateMap<UserSocialMedia, GetByUserSocialMediaDto>().ForMember(x => x.SocialMediaName, opt => opt.MapFrom(x => x.SocialMedia.SocialMediaName))
                                                                 .ReverseMap();
            CreateMap<IPaginate<UserSocialMedia>, UserSocialMediaModel>().ReverseMap();
        }
    }
}
