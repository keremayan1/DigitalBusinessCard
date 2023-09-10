using Application.Features.IbanInfos.Models;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.BankAccounts.Queries.GetList
{
    public class GetListIbanInfoQuery : IRequest<IbanInfoModel>
    {
        public class GetListIbanInfoQueryHandler : IRequestHandler<GetListIbanInfoQuery, IbanInfoModel>
        {
            private IIbanInfoRepository _ibanInfoRepository;
            private IMapper _mapper;

            public GetListIbanInfoQueryHandler(IIbanInfoRepository bankIbanInfoRepository, IMapper mapper)
            {
                _ibanInfoRepository = bankIbanInfoRepository;
                _mapper = mapper;
            }

            public async Task<IbanInfoModel> Handle(GetListIbanInfoQuery request, CancellationToken cancellationToken)
            {
                var models = await _ibanInfoRepository.GetListAsync(include: x => x.Include(x => x.IbanInfoImage));
                var result = _mapper.Map<IbanInfoModel>(models);
                return result;
            }
        }
    }
}
