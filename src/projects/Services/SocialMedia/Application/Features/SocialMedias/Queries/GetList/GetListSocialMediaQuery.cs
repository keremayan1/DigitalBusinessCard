using AutoMapper;
using MediatR;
using Application.Features.SocialMedias.DTOs;

using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Application.Features.SocialMedias.Models;

namespace Application.Features.SocialMedias.Queries.GetList
{
    public class GetListSocialMediaQuery:IRequest<SocialMediaModel>
    {
        public class GetListSocialMediasQueryHandler : IRequestHandler<GetListSocialMediaQuery, SocialMediaModel>
        {
            private ISocialMediaRepository _socialMediaRepository;
            private IMapper _mapper;

            public GetListSocialMediasQueryHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
            }

            public async Task<SocialMediaModel> Handle(GetListSocialMediaQuery request, CancellationToken cancellationToken)
            {
                var socialMedias = await _socialMediaRepository.GetListAsync(include:x=>x.Include(x=>x.SocialMediaImage));
                var result = _mapper.Map<SocialMediaModel>(socialMedias);
                return result;
            }
        }
    }
}
