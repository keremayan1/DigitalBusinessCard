using Application.Features.GameImages.Commands.Add;
using Application.Features.GameImages.Commands.Delete;
using Application.Features.GameImages.Commands.Update;
using Application.Features.GameImages.DTOs;
using AutoMapper;
using Domain.Entities.Concrete;

namespace Application.Features.GameImages.Profiles
{
    public class GameImageMapping : Profile
    {
        public GameImageMapping()
        {
            CreateMap<GameImage, CreatedGameImageDto>().ReverseMap();
            CreateMap<GameImage, CreateGameImageCommand>().ReverseMap();

            CreateMap<GameImage, UpdatedGameImageDto>().ReverseMap();
            CreateMap<GameImage, UpdateGameImageCommand>().ReverseMap();

            CreateMap<GameImage, DeletedGameImageDto>().ReverseMap();
            CreateMap<GameImage, DeleteGameImageCommand>().ReverseMap();
        }
    }
}
