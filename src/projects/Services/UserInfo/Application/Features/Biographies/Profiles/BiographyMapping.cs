using Application.Features.Biographies.Commands.Add;
using Application.Features.Biographies.Commands.Delete;
using Application.Features.Biographies.Commands.Update;
using Application.Features.Biographies.DTOs;
using Application.Features.Biographies.Models;
using AutoMapper;
using Core.Persistance.Paging;
using Domain.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Biographies.Profiles
{
    public class BiographyMapping:Profile
    {
        public BiographyMapping()
        {
            CreateMap<UserBiography, CreatedUserBiographyDto>().ReverseMap();
            CreateMap<UserBiography, CreateUserBiographyCommand>().ReverseMap();

            CreateMap<UserBiography, UpdatedUserBiographyDto>().ReverseMap();
            CreateMap<UserBiography, UpdateUserBiographyCommand>().ReverseMap();


            CreateMap<UserBiography, DeletedUserBiographyDto>().ReverseMap();
            CreateMap<UserBiography, DeleteUserBiographyCommand>().ReverseMap();

            CreateMap<IPaginate<UserBiography>, BiographyModel>().ReverseMap();
            CreateMap<UserBiography, GetListUserBiographyDto>().ReverseMap();
        }
    }
}
