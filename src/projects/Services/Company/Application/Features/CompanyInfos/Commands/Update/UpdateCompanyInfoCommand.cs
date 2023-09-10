using Application.Features.CompanyInfos.DTOs;
using Application.Services.AddressService;
using Application.Services.CompanyImageService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistance.Images;
using Core.Shared.Services;
using Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.CompanyInfos.Commands.Update
{
    public class UpdateCompanyInfoCommand : IRequest<UpdatedCompanyInfoDto>
    {
        public int Id { get; set; }
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
        public class UpdateCompanyInfoCommandHandler : IRequestHandler<UpdateCompanyInfoCommand, UpdatedCompanyInfoDto>
        {
            private ICompanyInfoRepository _companyInfoRepository;
            private IAddressService _addressService;
            private IMapper _mapper;

            private ISharedIdentityService _sharedIdentityService;
            private ICompanyInfoImageService _companyInfoImageService;

            public UpdateCompanyInfoCommandHandler(ICompanyInfoRepository companyInfoRepository,
                IAddressService addressService, IMapper mapper, ISharedIdentityService sharedIdentityService, ICompanyInfoImageService companyInfoImageService)
            {
                _companyInfoRepository = companyInfoRepository;
                _addressService = addressService;
                _mapper = mapper;

                _sharedIdentityService = sharedIdentityService;
                _companyInfoImageService = companyInfoImageService;
            }

            public async Task<UpdatedCompanyInfoDto> Handle(UpdateCompanyInfoCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<CompanyInfo>(request);
                mappedModel.UserId = _sharedIdentityService.GetUserId;
                await _companyInfoRepository.UpdateAsync(mappedModel);

                await _addressService.Update(new Address { CompanyId = request.Id, AddressName = request.AddressName, AddressDescription = request.AddressDescription });
                await _companyInfoImageService.UpdateCompanyInfoImage(new CompanyInfoImage 
                { CompanyId = mappedModel.Id }, request.Image, cancellationToken);
                var result = _mapper.Map<UpdatedCompanyInfoDto>(mappedModel);
                return result;
            }
        }
    }
}
