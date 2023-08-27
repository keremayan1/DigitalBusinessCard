using Application.Features.Sectors.Commands.Add;
using Application.Features.Sectors.Commands.Delete;
using Application.Features.Sectors.Commands.Update;
using Application.Features.Sectors.DTOs;
using Application.Features.Sectors.Models;
using AutoMapper;
using Core.Persistance.Paging;
using Domain.Entities.Concrete;

namespace Application.Features.Sectors.Profiles
{
    public class SectorMapping : Profile
    {
        public SectorMapping()
        {
            CreateMap<Sector, CreatedSectorDto>().ReverseMap();
            CreateMap<Sector, CreateSectorCommand>().ReverseMap();

            CreateMap<Sector, DeleteSectorCommand>().ReverseMap();
            CreateMap<Sector, DeletedSectorDto>().ReverseMap();

            CreateMap<Sector, UpdateSectorCommand>().ReverseMap();
            CreateMap<Sector, UpdatedSectorDto>().ReverseMap();

            CreateMap<Sector, GetBySectorDto>().ReverseMap();
            CreateMap<IPaginate<Sector>, SectorModel>().ReverseMap();
        }
    }
}
