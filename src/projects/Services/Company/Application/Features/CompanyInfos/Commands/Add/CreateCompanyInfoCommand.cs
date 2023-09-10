using Application.Features.CompanyInfos.DTOs;
using Application.Services.AddressService;
using Application.Services.CompanyImageService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Shared.Services;
using Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.CompanyInfos.Commands.Add
{
    public class CreateCompanyInfoCommand : IRequest<CreatedCompanyInfoDto>
    {
        public int SectorId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTitle { get; set; }
        public string CompanyWebSiteUrl { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyTelephoneNumber { get; set; }
        public string Info { get; set; }
        public string TaxNumber { get; set; }
        public string TaxInfo { get; set; }
        public string CompanyLogoPath { get; set; }
        public string AddressName { get; set; }
        public string AddressDescription { get; set; }
        public IFormFile Image { get; set; }
        public class CreateCompanyInfoCommandHandler : IRequestHandler<CreateCompanyInfoCommand, CreatedCompanyInfoDto>
        {
            private ICompanyInfoRepository _companyInfoRepository;
            private ISharedIdentityService _sharedIdentityService;
            private IAddressService _addressService;
            private IMapper _mapper;
            private ICompanyInfoImageService _companyInfoImageService;

            public CreateCompanyInfoCommandHandler(ICompanyInfoRepository companyInfoRepository, ISharedIdentityService sharedIdentityService, IAddressService addressService, IMapper mapper, ICompanyInfoImageService companyInfoImageService)
            {
                _companyInfoRepository = companyInfoRepository;
                _sharedIdentityService = sharedIdentityService;
                _addressService = addressService;

                _mapper = mapper;
                _companyInfoImageService = companyInfoImageService;
            }

            public async Task<CreatedCompanyInfoDto> Handle(CreateCompanyInfoCommand request, CancellationToken cancellationToken)
            {
                var mappedModels = _mapper.Map<CompanyInfo>(request);
                mappedModels.UserId = _sharedIdentityService.GetUserId;
                await _companyInfoRepository.AddAsync(mappedModels);


                await _addressService.Add(new Address
                { CompanyId = mappedModels.Id, AddressName = request.AddressName, AddressDescription = request.AddressDescription });
                await _companyInfoImageService.AddCompanyInfoImage(new CompanyInfoImage { CompanyId = mappedModels.Id }, request.Image,cancellationToken);
                var result = _mapper.Map<CreatedCompanyInfoDto>(mappedModels);
                return result;
            }
        }
    }
}
