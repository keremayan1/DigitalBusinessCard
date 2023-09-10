using Application.Features.IbanAccounts.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.IbanAccounts.Commands.Delete

{
    public class DeleteIbanAccountCommand : IRequest<DeletedIbanAccountDto>
    {
        public int Id { get; set; }
        public class DeleteIbanAccountCommandHandler : IRequestHandler<DeleteIbanAccountCommand, DeletedIbanAccountDto>
        {
            private readonly IIbanAccountRepository _companyBankIbanAccountRepository;
            private IMapper _mapper;

            public DeleteIbanAccountCommandHandler(IIbanAccountRepository companyBankIbanAccountRepository, IMapper mapper)
            {
                _companyBankIbanAccountRepository = companyBankIbanAccountRepository;
                _mapper = mapper;
            }

            public async Task<DeletedIbanAccountDto> Handle(DeleteIbanAccountCommand request, CancellationToken cancellationToken)
            {
                var getId = await _companyBankIbanAccountRepository.GetAsync(x => x.Id == request.Id);
                await _companyBankIbanAccountRepository.DeleteAsync(getId);


                var result = _mapper.Map<DeletedIbanAccountDto>(getId);
                return result;
            }
        }
    }
}
