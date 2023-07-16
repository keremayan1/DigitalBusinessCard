using Application.Features.SocialMedias.Commands.Add;
using Application.Features.SocialMedias.Commands.Delete;
using Application.Features.SocialMedias.Commands.Update;
using Application.Features.SocialMedias.DTOs;
using Application.Features.SocialMedias.Queries.GetList;
using AutoMapper;
using Domain.Entities.Concrete;

namespace Application.Features.SocialMedias.Profiles
{
    public class SocialMediaMapping:Profile
    {
        public SocialMediaMapping()
        {
            CreateMap<SocialMedia, CreatedSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaCommand>().ReverseMap();

            CreateMap<SocialMedia, UpdatedSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaCommand>().ReverseMap();

            CreateMap<SocialMedia, DeletedSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, DeleteSocialMediaCommand>().ReverseMap();

            CreateMap<SocialMedia, GetListSocialMediaDto>().ReverseMap();
            
        }
    }
}
