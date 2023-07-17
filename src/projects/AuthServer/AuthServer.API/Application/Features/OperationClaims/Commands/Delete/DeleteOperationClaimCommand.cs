using AuthServer.API.Application.Features.OperationClaims.DTOs;
using AuthServer.API.Application.Services.Repositories;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace AuthServer.API.Application.Features.OperationClaims.Commands.Delete
{
    public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { Permissions.Admin };
        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimDto>
        {
            private IOperationClaimRepository _operationClaimRepository;
            private IMapper _mapper;

            public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<DeletedOperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<OperationClaim>(request);
                await _operationClaimRepository.DeleteAsync(mappedModel);

                var result = _mapper.Map<DeletedOperationClaimDto>(mappedModel);
                return result;
            }
        }
    }
}
