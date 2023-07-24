using Application.Features.Games.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Games.Queries.GetList
{
    public class GetListGameQuery:IRequest<GameModel>//,ISecuredRequest
    {
    //  public string[] Roles => new[] { Permissions.Admin, Permissions.User };

        public class GetListGameQueryHandler : IRequestHandler<GetListGameQuery, GameModel>
        {
            private IGameRepository _gameRepository;
            private IMapper _mapper;

            public GetListGameQueryHandler(IGameRepository gameRepository, IMapper mapper)
            {
                _gameRepository = gameRepository;
                _mapper = mapper;
            }

            public async Task<GameModel> Handle(GetListGameQuery request, CancellationToken cancellationToken)
            {
                var models = await _gameRepository.GetListAsync(include: x=>x.Include(x=>x.GameImage));
                var result = _mapper.Map<GameModel>(models);
                return result;
            }
        }
    }
}
