using Application.Features.Addresses.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Core.Shared.Services;
using Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Commands.Add
{
    public class CreateAddressCommand:IRequest<CreatedAddressDto>
    {
        public string AddressName { get; set; }
        public string AddressDescription { get; set; }
        public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, CreatedAddressDto>
        {
            private IAddressRepository _addressRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;

            public CreateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper, ISharedIdentityService sharedIdentityService)
            {
                _addressRepository = addressRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
            }

            public async Task<CreatedAddressDto> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<Address>(request);

                mappedModel.UserId = _sharedIdentityService.GetUserId;
                await _addressRepository.AddAsync(mappedModel);

                var result = _mapper.Map<CreatedAddressDto>(mappedModel);
                return result;

            }
        }
    }
}
