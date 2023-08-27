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

namespace Application.Features.Sectors.Commands.Delete
{
    public class DeleteSectorCommand : IRequest<DeletedSectorDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { Permissions.Admin };
        public class DeleteSectorCommandHandler : IRequestHandler<DeleteSectorCommand, DeletedSectorDto>
        {
            private readonly ISectorRepository _sectorRepository;
            private readonly IMapper _mapper;

            public DeleteSectorCommandHandler(ISectorRepository sectorRepository, IMapper mapper)
            {
                _sectorRepository = sectorRepository;
                _mapper = mapper;
            }

            public async Task<DeletedSectorDto> Handle(DeleteSectorCommand request, CancellationToken cancellationToken)
            {
                var getId = await _sectorRepository.GetAsync(x => x.Id == request.Id);
                await _sectorRepository.DeleteAsync(getId);

                var result = _mapper.Map<DeletedSectorDto>(getId);
                return result;
            }
        }
    }
}
