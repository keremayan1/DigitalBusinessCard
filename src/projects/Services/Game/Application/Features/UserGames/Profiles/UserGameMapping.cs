using Application.Features.UserGames.Commands.Add;
using Application.Features.UserGames.Commands.Delete;
using Application.Features.UserGames.Commands.Update;
using Application.Features.UserGames.DTOs;
using Application.Features.UserGames.Models;
using AutoMapper;
using Core.Persistance.Paging;
using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGames.Profiles
{
    public class UserGameMapping : Profile
    {
        public UserGameMapping()
        {
            CreateMap<UserGame, CreatedUserGameDto>().ReverseMap();
            CreateMap<UserGame, CreateUserGameCommand>().ReverseMap();

            CreateMap<UserGame, DeletedUserGameDto>().ReverseMap();
            CreateMap<UserGame, DeleteUserGameCommand>().ReverseMap();

            CreateMap<UserGame, UpdatedUserGameDto>().ReverseMap();
            CreateMap<UserGame, UpdateUserGameCommand>().ReverseMap();

            CreateMap<UserGame, GetByUserGameDto>().ForMember(x=>x.GameName,opt=>opt.MapFrom(x=>x.Game.GameName)).ReverseMap();
            CreateMap<IPaginate<UserGame>, UserGameModel>().ReverseMap();
        }
    }
}
