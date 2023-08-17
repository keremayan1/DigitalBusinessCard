using AutoMapper;
using Core.Shared.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.Features.UserCryptos.Models;
using WebAPI.Application.Services.Repositories;

namespace WebAPI.Application.Features.UserCryptos.Queries.GetList
{
    public class GetListUserCryptoQuery:IRequest<UserCryptoModel>
    {
        public class GetListUserCryptoQueryHandler : IRequestHandler<GetListUserCryptoQuery, UserCryptoModel>
        {
            private readonly IUserCryptoRepository _userCryptoRepository;
            private readonly IMapper _mapper;
            private readonly ISharedIdentityService _sharedIdentityService;

            public GetListUserCryptoQueryHandler(IUserCryptoRepository userCryptoRepository, IMapper mapper, ISharedIdentityService sharedIdentityService)
            {
                _userCryptoRepository = userCryptoRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
            }

            public async Task<UserCryptoModel> Handle(GetListUserCryptoQuery request, CancellationToken cancellationToken)
            {
                var models = await _userCryptoRepository.GetListAsync(x => x.UserId == _sharedIdentityService.GetUserId, include: x => x.Include(x => x.Crypto));
                var result= _mapper.Map<UserCryptoModel>(models);
                return result;
            }
        }
    }
}
