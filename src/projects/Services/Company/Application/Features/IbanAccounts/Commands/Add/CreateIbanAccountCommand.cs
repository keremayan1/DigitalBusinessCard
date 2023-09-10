using Application.Features.IbanAccounts.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Core.Shared.Services;
using Domain.Entities.Concrete;
using MediatR;

namespace Application.Features.IbanAccounts.Commands.Add
{
    public class CreateIbanAccountCommand : IRequest<CreatedIbanAccountDto>
    {
        public int IbanInfoId { get; set; }
        public string IbanUserName { get; set; }
        public string IbanNumber { get; set; }
        public class CreateIbanAccountCommandHandler : IRequestHandler<CreateIbanAccountCommand, CreatedIbanAccountDto>
        {
            private readonly IIbanAccountRepository _companyBankIbanAccountRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;

            public CreateIbanAccountCommandHandler(IIbanAccountRepository companyBankIbanAccountRepository, IMapper mapper, ISharedIdentityService sharedIdentityService)
            {
                _companyBankIbanAccountRepository = companyBankIbanAccountRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
            }

            public async Task<CreatedIbanAccountDto> Handle(CreateIbanAccountCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<IbanAccount>(request);
                mappedModel.UserId = _sharedIdentityService.GetUserId;
                await _companyBankIbanAccountRepository.AddAsync(mappedModel);


                var result = _mapper.Map<CreatedIbanAccountDto>(mappedModel);
                return result;
            }
        }
    }
}
