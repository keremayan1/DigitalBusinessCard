using Application.Features.CompanyInfos.DTOs;
using Application.Services.AddressService.Dtos;
using Application.Services.AddressService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistance.Images;
using Core.Shared.Services;
using Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.CompanyImageService;

namespace Application.Features.CompanyInfos.Commands.Delete
{
    public class DeleteCompanyInfoCommand : IRequest<DeletedCompanyInfoDto>
    {
        public int Id { get; set; }
        public class DeleteCompanyInfoCommandHandler : IRequestHandler<DeleteCompanyInfoCommand, DeletedCompanyInfoDto>
        {
            private ICompanyInfoRepository _companyInfoRepository;
            private ISharedIdentityService _sharedIdentityService;
            private IAddressService _addressService;
            private ImageService _imageService;
            private IMapper _mapper;
            private ICompanyInfoImageService _companyInfoImageService;

            public DeleteCompanyInfoCommandHandler(ICompanyInfoRepository companyInfoRepository, ISharedIdentityService sharedIdentityService, IAddressService addressService, ImageService imageService, IMapper mapper, ICompanyInfoImageService companyInfoImageService)
            {
                _companyInfoRepository = companyInfoRepository;
                _sharedIdentityService = sharedIdentityService;
                _addressService = addressService;
                _imageService = imageService;
                _mapper = mapper;
                _companyInfoImageService = companyInfoImageService;
            }

            public async Task<DeletedCompanyInfoDto> Handle(DeleteCompanyInfoCommand request, CancellationToken cancellationToken)
            {
                var getId = await _companyInfoRepository.GetAsync(x => x.Id == request.Id);

                await _companyInfoImageService.DeleteCompanyInfoImage(getId.Id);
                await _addressService.Delete(getId.Id);
                await _companyInfoRepository.DeleteAsync(getId);
                var result = _mapper.Map<DeletedCompanyInfoDto>(getId);
                return result;
            }
        }
    }
}
