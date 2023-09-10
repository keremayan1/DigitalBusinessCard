using Application.Features.CompanyInfos.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Shared.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CompanyInfos.Queries.GetList
{
    public class GetListCompanyInfoQuery:IRequest<CompanyInfoModel>
    {
        public class GetListCompanyInfoQueryHandler : IRequestHandler<GetListCompanyInfoQuery, CompanyInfoModel>
        {
            private ICompanyInfoRepository _companyInfoRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;

            public GetListCompanyInfoQueryHandler(ICompanyInfoRepository companyInfoRepository, IMapper mapper, ISharedIdentityService sharedIdentityService)
            {
                _companyInfoRepository = companyInfoRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
            }

            public async Task<CompanyInfoModel> Handle(GetListCompanyInfoQuery request, CancellationToken cancellationToken)
            {
                var models = await _companyInfoRepository.GetListAsync(x => x.UserId == _sharedIdentityService.GetUserId, include: x => x.Include(j => j.Sector)
                  .Include(j => j.CompanyInfoImage));
                var result = _mapper.Map<CompanyInfoModel>(models);
                return result;
            }
        }
    }
}
