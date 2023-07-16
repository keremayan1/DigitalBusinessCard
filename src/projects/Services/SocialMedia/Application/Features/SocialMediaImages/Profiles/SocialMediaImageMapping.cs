using Application.Features.SocialMediaImages.Commands.Add;
using Application.Features.SocialMediaImages.Commands.Delete;
using Application.Features.SocialMediaImages.Commands.Update;
using Application.Features.SocialMediaImages.DTOs;
using Application.Features.SocialMedias.DTOs;
using AutoMapper;
using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaImages.Profiles
{
    public class SocialMediaImageMapping : Profile
    {
        public SocialMediaImageMapping()
        {
            CreateMap<SocialMediaImage, CreatedSocialMediaImageDto>().ReverseMap();
            CreateMap<SocialMediaImage, CreateSocialMediaImageCommand>().ReverseMap();

            CreateMap<SocialMediaImage, UpdatedSocialMediaImageDto>().ReverseMap();
            CreateMap<SocialMediaImage, UpdateSocialMediaImageCommand>().ReverseMap();

            CreateMap<SocialMediaImage, DeletedSocialMediaImageDto>().ReverseMap();
            CreateMap<SocialMediaImage, DeleteSocialMediaImageCommand>().ReverseMap();
        }
    }
}
