using Application.Features.IbanAccounts.Commands.Add;
using Application.Features.IbanAccounts.Commands.Delete;
using Application.Features.IbanAccounts.Commands.Update;
using Application.Features.IbanAccounts.DTOs;
using Application.Features.IbanAccounts.Models;
using AutoMapper;
using Core.Persistance.Paging;
using Domain.Entities.Concrete;

namespace Application.Features.IbanAccounts.Profiles
{
    public class CompanyIbanAccountMapping : Profile
    {
        public CompanyIbanAccountMapping()
        {
            CreateMap<IbanAccount, CreatedIbanAccountDto>().ReverseMap();
            CreateMap<IbanAccount, CreateIbanAccountCommand>().ReverseMap();

            CreateMap<IbanAccount, UpdatedIbanAccountDto>().ReverseMap();
            CreateMap<IbanAccount, UpdateIbanAccountCommand>().ReverseMap();

            CreateMap<IbanAccount, DeletedIbanAccountDto>().ReverseMap();
            CreateMap<IbanAccount, DeleteIbanAccountCommand>().ReverseMap();

            CreateMap<IPaginate<IbanAccount>, IbanAccountModel>().ReverseMap();
            CreateMap<IbanAccount, GetByIbanAccountDto>()
                .ForMember(x => x.IbanNameAndNumber,
                opt => opt.MapFrom(x => x.IbanInfo.Code + x.IbanNumber)).ReverseMap();
        }
    }
}
