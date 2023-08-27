using Application.Features.Addresses.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Commands.Delete
{
    public class DeleteAddressCommand : IRequest<DeletedAddressDto>
    {
        public int Id { get; set; }
        public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, DeletedAddressDto>
        {
            private IAddressRepository _addressRepository;
            private IMapper _mapper;

            public DeleteAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper)
            {
                _addressRepository = addressRepository;
                _mapper = mapper;
            }

            public async Task<DeletedAddressDto> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
            {
                var getId = await _addressRepository.GetAsync(x => x.Id == request.Id);
                await _addressRepository.DeleteAsync(getId);

                var result = _mapper.Map<DeletedAddressDto>(getId);
                return result;

            }
        }
    }
}
