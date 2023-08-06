using AutoMapper;
using Core.Persistance.Paging;
using IBANAccount.API.Application.Features.Iban.Commands.Add;
using IBANAccount.API.Application.Features.Iban.Commands.Delete;
using IBANAccount.API.Application.Features.Iban.Commands.Update;
using IBANAccount.API.Application.Features.Iban.DTOs;
using IBANAccount.API.Application.Features.Iban.Models;
using IBANAccount.API.Domain.Entities;

namespace IBANAccount.API.Application.Features.Iban.Profiles
{
    public class IbanMapping:Profile
    {
        public IbanMapping()
        {
            CreateMap<Domain.Entities.Iban, CreatedIbanDto>().ReverseMap();
            CreateMap<Domain.Entities.Iban, CreateIbanCommand>().ReverseMap();

            CreateMap<Domain.Entities.Iban, UpdatedIbanDto>().ReverseMap();
            CreateMap<Domain.Entities.Iban, UpdateIbanCommand>().ReverseMap();

            CreateMap<Domain.Entities.Iban, DeletedIbanDto>().ReverseMap();
            CreateMap<Domain.Entities.Iban, DeleteIbanCommand>().ReverseMap();

            CreateMap<IPaginate<Domain.Entities.Iban>, IbanModel>().ReverseMap();
            CreateMap<Domain.Entities.Iban, GetIbanDto>().ForMember(x=>x.ImagePath,opt=>opt.MapFrom(x=>x.IbanImage.ImagePath)).ReverseMap();
        }
    }
}
