using Application.Features.Addresses.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Core.Shared.Services;
using Domain.Entities.Concrete;
using MediatR;

namespace Application.Features.Addresses.Commands.Update
{
    public class UpdateAddressCommand : IRequest<UpdatedAddressDto>
    {
        public  int Id { get; set; }
        public string AddressName { get; set; }
        public string AddressDescription { get; set; }
        public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, UpdatedAddressDto>
        {
            private IAddressRepository _addressRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;
            public UpdateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper, ISharedIdentityService sharedIdentityService)
            {
                _addressRepository = addressRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
            }
            public async Task<UpdatedAddressDto> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<Address>(request);
                mappedModel.UserId = _sharedIdentityService.GetUserId;

                await _addressRepository.UpdateAsync(mappedModel);

                var result = _mapper.Map<UpdatedAddressDto>(mappedModel);
                return result;

            }
        }
    }
}
