using Application.Features.Biographies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Shared.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Biographies.Queries.GetByUserId
{
    public class GetByBiographyUserIdQuery:IRequest<BiographyModel>
    {
        public class GetByBiographyUserIdQueryHandler : IRequestHandler<GetByBiographyUserIdQuery, BiographyModel>
        {
            private IUserBiographyRepository _userBiographyRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;

            public GetByBiographyUserIdQueryHandler(IUserBiographyRepository userBiographyRepository, IMapper mapper, ISharedIdentityService sharedIdentityService)
            {
                _userBiographyRepository = userBiographyRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
            }

            public async Task<BiographyModel> Handle(GetByBiographyUserIdQuery request, CancellationToken cancellationToken)
            {
                var model = await _userBiographyRepository.GetListAsync(x => x.UserId == _sharedIdentityService.GetUserId);
                var result = _mapper.Map<BiographyModel>(model);
                return result;
            }
        }
    }
}
