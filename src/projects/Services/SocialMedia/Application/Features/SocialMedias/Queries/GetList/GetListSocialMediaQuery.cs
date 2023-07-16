using AutoMapper;
using MediatR;
using Application.Features.SocialMedias.DTOs;

using Application.Services.Repositories;

namespace Application.Features.SocialMedias.Queries.GetList
{
    public class GetListSocialMediaQuery:IRequest<List<GetListSocialMediaDto>>
    {
        public class GetListSocialMediasQueryHandler : IRequestHandler<GetListSocialMediaQuery, List<GetListSocialMediaDto>>
        {
            private ISocialMediaRepository _socialMediaRepository;
            private IMapper _mapper;

            public GetListSocialMediasQueryHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
            }

            public async Task<List<GetListSocialMediaDto>> Handle(GetListSocialMediaQuery request, CancellationToken cancellationToken)
            {
                var socialMedias = await _socialMediaRepository.GetListWithoutInclude();
                var result = _mapper.Map<List<GetListSocialMediaDto>>(socialMedias);
                return result;
            }
        }
    }
}
