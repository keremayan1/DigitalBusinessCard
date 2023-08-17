using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebAPI.Application.Features.Cryptos.Models;
using WebAPI.Application.Services.Repositories;

namespace WebAPI.Application.Features.Cryptos.Queries.GetList
{
    public class GetListCryptoQuery:IRequest<CryptoModel>,ISecuredRequest
    {
        public string[] Roles => new[] { Permissions.Admin, Permissions.Moderator,Permissions.User };
        public class GetListCryptoQueryHandler : IRequestHandler<GetListCryptoQuery, CryptoModel>
        {
            private readonly ICryptoRepository _cryptoRepository;
            private readonly IMapper _mapper;

            public GetListCryptoQueryHandler(ICryptoRepository cryptoRepository, IMapper mapper)
            {
                _cryptoRepository = cryptoRepository;
                _mapper = mapper;
            }

            public async Task<CryptoModel> Handle(GetListCryptoQuery request, CancellationToken cancellationToken)
            {
                var models = await _cryptoRepository.GetListAsync(include: x => x.Include(x => x.CryptoImage));
                var result = _mapper.Map<CryptoModel>(models);
                return result;
            }
        }
    }
}
