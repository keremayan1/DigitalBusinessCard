using Application.Features.IbanInfos.Commands.Add;
using Application.Features.IbanInfos.Commands.Delete;
using Application.Features.IbanInfos.Commands.Update;
using Application.Features.IbanInfos.DTOs;
using Application.Features.IbanInfos.Models;
using AutoMapper;
using Core.Persistance.Paging;
using Domain.Entities.Concrete;

namespace Application.Features.BankAccounts.Profiles
{
    public class BankIbanAccountMapping : Profile
    {
        public BankIbanAccountMapping()
        {
            CreateMap<IbanInfo, CreateIbanInfoCommand>().ReverseMap();
            CreateMap<IbanInfo, CreatedIbanInfoDto>().ReverseMap();

            CreateMap<IbanInfo, DeleteIbanInfoCommand>().ReverseMap();
            CreateMap<IbanInfo, DeletedIbanInfoDto>().ReverseMap();

            CreateMap<IbanInfo, UpdateIbanInfoCommand>().ReverseMap();
            CreateMap<IbanInfo, UpdatedIbanInfoDto>().ReverseMap();

            CreateMap<IPaginate<IbanInfo>, IbanInfoModel>().ReverseMap();
            CreateMap<IbanInfo, GetByIbanInfoDto>().
                ForMember(x => x.ImagePath, opt => opt.MapFrom(x => x.IbanInfoImage.ImagePath)).ReverseMap();

        }
    }
}
