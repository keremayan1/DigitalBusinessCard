using Application.Features.IbanAccounts.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Core.Shared.Services;
using Domain.Entities.Concrete;
using MediatR;

namespace Application.Features.IbanAccounts.Commands.Update
{
    public class UpdateIbanAccountCommand : IRequest<UpdatedIbanAccountDto>
    {
        public int Id { get; set; }
        public int IbanInfoId { get; set; }
        public string IbanUserName { get; set; }
        public string IbanNumber { get; set; }
        public class UpdateIbanAccountCommandHandler : IRequestHandler<UpdateIbanAccountCommand, UpdatedIbanAccountDto>
        {
            private readonly IIbanAccountRepository _companyBankIbanAccountRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;

            public UpdateIbanAccountCommandHandler(IIbanAccountRepository companyBankIbanAccountRepository, IMapper mapper, ISharedIdentityService sharedIdentityService)
            {
                _companyBankIbanAccountRepository = companyBankIbanAccountRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
            }

            public async Task<UpdatedIbanAccountDto> Handle(UpdateIbanAccountCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<IbanAccount>(request);
                mappedModel.UserId = _sharedIdentityService.GetUserId;
                await _companyBankIbanAccountRepository.UpdateAsync(mappedModel);


                var result = _mapper.Map<UpdatedIbanAccountDto>(mappedModel);
                return result;
            }
        }
    }

}
