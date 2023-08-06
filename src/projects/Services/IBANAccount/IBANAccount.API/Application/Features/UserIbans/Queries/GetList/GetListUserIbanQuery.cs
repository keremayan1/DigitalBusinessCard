using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Core.Shared.Services;
using IBANAccount.API.Application.Features.UserIbans.Models;
using IBANAccount.API.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IBANAccount.API.Application.Features.UserIbans.Queries.GetList
{
    public class GetListUserIbanQuery:IRequest<UserIbanModel>,ISecuredRequest
    {
        public string[] Roles => new[] { Permissions.User, Permissions.Admin, Permissions.Moderator };
        public class GetListUserIbanQueryHandler : IRequestHandler<GetListUserIbanQuery, UserIbanModel>
        {
            private IUserIbanRepository _userIbanRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;

            public GetListUserIbanQueryHandler(IUserIbanRepository userIbanRepository, IMapper mapper, ISharedIdentityService sharedIdentityService)
            {
                _userIbanRepository = userIbanRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
            }

            public async Task<UserIbanModel> Handle(GetListUserIbanQuery request, CancellationToken cancellationToken)
            {
                var models = await _userIbanRepository.GetListAsync(x => x.UserId == _sharedIdentityService.GetUserId, include: x => x.Include(x => x.Iban));
                var result = _mapper.Map<UserIbanModel>(models);
                return result;
            }
        }
    }
}
