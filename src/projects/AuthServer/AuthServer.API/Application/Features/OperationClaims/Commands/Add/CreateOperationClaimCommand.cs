using AuthServer.API.Application.Features.OperationClaims.DTOs;
using AuthServer.API.Application.Services.Repositories;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace AuthServer.API.Application.Features.OperationClaims.Commands.Add
{
    public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>, ISecuredRequest
    {
        public string Name { get; set; }
        public string[] Roles => new[] { Permissions.Admin };
        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
        {
            private IOperationClaimRepository _operationClaimRepository;
            private IMapper _mapper;

            public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
            }

            public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<OperationClaim>(request);
                await _operationClaimRepository.AddAsync(mappedModel);

                var result = _mapper.Map<CreatedOperationClaimDto>(mappedModel);
                return result;
            }
        }
    }
}
