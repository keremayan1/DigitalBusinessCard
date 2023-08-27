using Application.Features.Addresses.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Shared.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Queries.GetList
{
    public class GetListAddressQuery:IRequest<AddressModel>
    {
        public class GetListAddressQueryHandler : IRequestHandler<GetListAddressQuery, AddressModel>
        {
            private IAddressRepository _addressRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;
            public GetListAddressQueryHandler(IAddressRepository addressRepository, IMapper mapper)
            {
                _addressRepository = addressRepository;
                _mapper = mapper;
            }

            public async Task<AddressModel> Handle(GetListAddressQuery request, CancellationToken cancellationToken)
            {
                var models = await _addressRepository.GetListAsync(x=>x.UserId==_sharedIdentityService.GetUserId);
                var result = _mapper.Map<AddressModel>(models);
                return result;
            }
        }
    }
}
