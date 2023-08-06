using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using IBANAccount.API.Application.Features.Iban.Models;
using IBANAccount.API.Application.Services.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace IBANAccount.API.Application.Features.Iban.Queries.GetList
{
    public class GetListIbanQuery : IRequest<IbanModel>, ISecuredRequest
    {
        public string[] Roles => new[] { Permissions.Admin };

        public class GetListIbanQueryHandler : IRequestHandler<GetListIbanQuery, IbanModel>
        {
            private IIbanRepository _ibanRepository;
            private IMapper _mapper;

            public GetListIbanQueryHandler(IIbanRepository ibanRepository, IMapper mapper)
            {
                _ibanRepository = ibanRepository;
                _mapper = mapper;
            }

            public async Task<IbanModel> Handle(GetListIbanQuery request, CancellationToken cancellationToken)
            {
                var models = await _ibanRepository.GetListAsync(include:x=>x.Include(x=>x.IbanImage));
                var result = _mapper.Map<IbanModel>(models);
                return result;
            }
        }
    }
}
