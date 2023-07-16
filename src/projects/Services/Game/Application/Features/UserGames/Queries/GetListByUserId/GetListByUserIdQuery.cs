using Application.Features.UserGames.Models;
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

namespace Application.Features.UserGames.Queries.GetListByUserId
{
    public class GetListByUserIdQuery:IRequest<UserGameModel>
    {
        public class GetListByUserIdQueryHandler : IRequestHandler<GetListByUserIdQuery, UserGameModel>
        {
            private IUserGameRepository _userGameRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;

            public GetListByUserIdQueryHandler(IUserGameRepository userGameRepository, IMapper mapper, ISharedIdentityService sharedIdentityService)
            {
                _userGameRepository = userGameRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
            }

            public async Task<UserGameModel> Handle(GetListByUserIdQuery request, CancellationToken cancellationToken)
            {
                var models = await _userGameRepository.GetListAsync(x => x.UserId == _sharedIdentityService.GetUserId,
                                                                    include: x => x.Include(x => x.Game));
                var result =  _mapper.Map<UserGameModel>(models);
                return result;

            }
        }
    }
}
