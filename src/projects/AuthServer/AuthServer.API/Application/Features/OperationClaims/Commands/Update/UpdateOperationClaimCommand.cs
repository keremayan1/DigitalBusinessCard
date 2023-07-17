using AuthServer.API.Application.Features.OperationClaims.DTOs;
using AuthServer.API.Application.Services.Repositories;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace AuthServer.API.Application.Features.OperationClaims.Commands.Update
{
    public class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string[] Roles => new[] { Permissions.Admin };
        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
        {
            private IOperationClaimRepository _operationClaimRepository;
            private IMapper _mapper;

            public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<OperationClaim>(request);
                await _operationClaimRepository.UpdateAsync(mappedModel);

                var result = _mapper.Map<UpdatedOperationClaimDto>(mappedModel);
                return result;
            }
        }
    }
}
