using AutoMapper;
using Core.Persistance.Paging;
using WebAPI.Application.Features.Cryptos.Commands.Add;
using WebAPI.Application.Features.Cryptos.Commands.Delete;
using WebAPI.Application.Features.Cryptos.Commands.Update;
using WebAPI.Application.Features.Cryptos.DTOs;
using WebAPI.Application.Features.Cryptos.Models;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Features.Cryptos.Profiles
{
    public class CryptoMapping : Profile
    {
        public CryptoMapping()
        {
            CreateMap<Crypto, CreatedCryptoDto>().ReverseMap();
            CreateMap<Crypto, CreateCryptoCommand>().ReverseMap();

            CreateMap<Crypto, DeletedCryptoDto>().ReverseMap();
            CreateMap<Crypto, DeleteCryptoCommand>().ReverseMap();

            CreateMap<Crypto, UpdatedCryptoDto>().ReverseMap();
            CreateMap<Crypto, UpdateCryptoCommand>().ReverseMap();

            CreateMap<Crypto, GetListCryptoDto>().ForMember(x=>x.ImagePath,opt=>opt.MapFrom(x=>x.CryptoImage.ImagePath)).ReverseMap();
            CreateMap<IPaginate<Crypto>, CryptoModel>().ReverseMap();
        }
    }
}
