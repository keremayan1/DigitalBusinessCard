using Application.Features.Images.Commands.Add;
using Application.Features.Images.Commands.Delete;
using Application.Features.Images.Commands.Update;
using Application.Features.Images.DTOs;
using Application.Features.Images.Models;
using AutoMapper;
using Core.Persistance.Paging;
using Domain.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Images.Profiles
{
    public class UserImageMapping:Profile
    {
        public UserImageMapping()
        {
            CreateMap<UserImage, CreatedUserImageDto>().ReverseMap();
            CreateMap<UserImage, CreateUserImageCommand>().ReverseMap();

            CreateMap<UserImage, UpdatedUserImageDto>().ReverseMap();
            CreateMap<UserImage, UpdateUserImageCommand>().ReverseMap();

            CreateMap<UserImage, DeletedUserImageDto>().ReverseMap();
            CreateMap<UserImage, DeleteUserImageCommand>().ReverseMap();

            CreateMap<IPaginate<UserImage>, UserImageModel>().ReverseMap();
            CreateMap<UserImage, GetByUserImageDto>().ReverseMap();
            //CreateMap<UserImage, CreateUserImageCommand>().ReverseMap();
        }
    }
}
