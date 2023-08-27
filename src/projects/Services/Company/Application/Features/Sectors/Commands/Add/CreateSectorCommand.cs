using Application.Features.Sectors.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Domain.Entities.Concrete;
using MediatR;

namespace Application.Features.Sectors.Commands.Add
{
    public class CreateSectorCommand : IRequest<CreatedSectorDto>, ISecuredRequest
    {
        public string SectorName { get; set; }

        public string[] Roles => new[] { Permissions.Admin };

        public class CreateSectorCommandHandler : IRequestHandler<CreateSectorCommand, CreatedSectorDto>
        {
            private readonly ISectorRepository _sectorRepository;
            private readonly IMapper _mapper;

            public CreateSectorCommandHandler(ISectorRepository sectorRepository, IMapper mapper)
            {
                _sectorRepository = sectorRepository;
                _mapper = mapper;
            }

            public async Task<CreatedSectorDto> Handle(CreateSectorCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<Sector>(request);
                await _sectorRepository.AddAsync(mappedModel);

                var result = _mapper.Map<CreatedSectorDto>(mappedModel);
                return result;
            }
        }
    }
}
