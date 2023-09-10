using Application.Features.CompanyInfos.Commands.Add;
using Application.Features.CompanyInfos.Commands.Delete;
using Application.Features.CompanyInfos.Commands.Update;
using Application.Features.CompanyInfos.DTOs;
using Application.Features.CompanyInfos.Models;
using AutoMapper;
using Core.Persistance.Paging;
using Domain.Entities.Concrete;

namespace Application.Features.CompanyInfos.Profiles
{
    public class CompanyInfoMapping : Profile
    {
        public CompanyInfoMapping()
        {
            CreateMap<CompanyInfo, CreatedCompanyInfoDto>().ReverseMap();
            CreateMap<CompanyInfo, CreateCompanyInfoCommand>().ReverseMap();

            CreateMap<CompanyInfo, UpdatedCompanyInfoDto>().ReverseMap();
            CreateMap<CompanyInfo, UpdateCompanyInfoCommand>().ReverseMap();


            CreateMap<CompanyInfo, DeletedCompanyInfoDto>().ReverseMap();
            CreateMap<CompanyInfo, DeleteCompanyInfoCommand>().ReverseMap();

            CreateMap<CompanyInfo, GetByCompanyInfoDto>().ForMember(x => x.ImagePath, opt => opt.MapFrom(x => x.CompanyInfoImage.ImagePath))
                                                         .ForMember(x => x.SectorName, opt => opt.MapFrom(x => x.Sector.SectorName))
                                                         .ReverseMap();
            CreateMap<IPaginate<CompanyInfo>, CompanyInfoModel>().ReverseMap();
        }
    }
}
