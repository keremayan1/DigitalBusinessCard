using Application.Features.Games.Commands.Add;
using Application.Features.Games.Commands.Delete;
using Application.Features.Games.Commands.Update;
using Application.Features.Games.DTOs;
using AutoMapper;
using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Games.Profiles
{
    public class GameMapping:Profile
    {
        public GameMapping()
        {
            CreateMap<Game, CreatedGameDto>().ReverseMap();
            CreateMap<Game, CreateGameCommand>().ReverseMap();

            CreateMap<Game, UpdatedGameDto>().ReverseMap();
            CreateMap<Game, UpdateGameCommand>().ReverseMap();

            CreateMap<Game, DeletedGameDto>().ReverseMap();
            CreateMap<Game, DeleteGameCommand>().ReverseMap();
        }
    }
}
