using Application.Features.Sectors.Models;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sectors.Queries.GetList
{
    public class GetListSectorQuery:IRequest<SectorModel>
    {
        public class GetListSectorQueryHandler : IRequestHandler<GetListSectorQuery, SectorModel>
        {
            private readonly ISectorRepository _sectorRepository;
            private readonly IMapper _mapper;

            public GetListSectorQueryHandler(ISectorRepository sectorRepository, IMapper mapper)
            {
                _sectorRepository = sectorRepository;
                _mapper = mapper;
            }

            public async Task<SectorModel> Handle(GetListSectorQuery request, CancellationToken cancellationToken)
            {
                var models = await _sectorRepository.GetListAsync();
                var result = _mapper.Map<SectorModel>(models);
                return result;
            }
        }
    }
}
