using Application.Features.TelephoneNumbers.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Shared.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TelephoneNumbers.Queries.GetByUserId
{
    public class GetByTelephoneNumberUserIdQuery:IRequest<UserTelephoneNumberModel>
    {
        public class GetByTelephoneNumberUserIdQueryHandler : IRequestHandler<GetByTelephoneNumberUserIdQuery, UserTelephoneNumberModel>
        {
            private IUserTelephoneNumberRepository _userTelephoneNumberRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;

            public GetByTelephoneNumberUserIdQueryHandler(IUserTelephoneNumberRepository userTelephoneNumberRepository, IMapper mapper, ISharedIdentityService sharedIdentityService)
            {
                _userTelephoneNumberRepository = userTelephoneNumberRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
            }

            public async Task<UserTelephoneNumberModel> Handle(GetByTelephoneNumberUserIdQuery request, CancellationToken cancellationToken)
            {
                var model = await _userTelephoneNumberRepository.GetListAsync(x => x.UserId == _sharedIdentityService.GetUserId,include:x=>x.Include(x=>x.UserTelephoneType).Include(x=>x.UserTelephoneCountry));
                var result = _mapper.Map<UserTelephoneNumberModel>(model);
                return result;
            }
        }
    }
}
