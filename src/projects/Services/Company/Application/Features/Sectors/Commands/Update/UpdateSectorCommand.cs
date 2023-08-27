using Application.Features.Sectors.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sectors.Commands.Update
{
    public class UpdateSectorCommand : IRequest<UpdatedSectorDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string SectorName { get; set; }
        public string[] Roles => new[] { Permissions.Admin };
        public class UpdateSectorCommandHandler : IRequestHandler<UpdateSectorCommand, UpdatedSectorDto>
        {
            private readonly ISectorRepository _sectorRepository;
            private readonly IMapper _mapper;

            public UpdateSectorCommandHandler(ISectorRepository sectorRepository, IMapper mapper)
            {
                _sectorRepository = sectorRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedSectorDto> Handle(UpdateSectorCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<Sector>(request);
                await _sectorRepository.UpdateAsync(mappedModel);

                var result = _mapper.Map<UpdatedSectorDto>(mappedModel);
                return result;
            }
        }
    }
}
