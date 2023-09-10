using Application.Features.IbanAccounts.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Shared.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.IbanAccounts.Queries.GetList
{
    public class GetListIbanAccountQuery : IRequest<IbanAccountModel>
    {
        public class GetListIbanAccountQueryHandler : IRequestHandler<GetListIbanAccountQuery, IbanAccountModel>
        {
            private IIbanAccountRepository _companyBankIbanAccountRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;


            public GetListIbanAccountQueryHandler(IIbanAccountRepository companyBankIbanAccountRepository, IMapper mapper, ISharedIdentityService sharedIdentityService)
            {
                _companyBankIbanAccountRepository = companyBankIbanAccountRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
            }

            public async Task<IbanAccountModel> Handle(GetListIbanAccountQuery request, CancellationToken cancellationToken)
            {
                var models = await _companyBankIbanAccountRepository.GetListAsync(x => x.UserId == _sharedIdentityService.GetUserId, include: x => x.Include(x => x.IbanInfo));
                var result = _mapper.Map<IbanAccountModel>(models);
                return result;
            }
        }
    }
}
