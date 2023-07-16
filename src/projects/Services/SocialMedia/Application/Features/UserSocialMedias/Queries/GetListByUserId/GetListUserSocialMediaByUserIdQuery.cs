using Application.Features.UserSocialMedias.Models;
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

namespace Application.Features.UserSocialMedias.Queries.GetListByUserId
{
    public class GetListUserSocialMediaByUserIdQuery:IRequest<UserSocialMediaModel>
    {
        public class GetListUserSocialMediaByUserIdQueryHandler : IRequestHandler<GetListUserSocialMediaByUserIdQuery, UserSocialMediaModel>
        {
            private IUserSocialMediaRepository _userSocialMediaRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;

            public GetListUserSocialMediaByUserIdQueryHandler(IUserSocialMediaRepository userSocialMediaRepository, IMapper mapper, ISharedIdentityService sharedIdentityService)
            {
                _userSocialMediaRepository = userSocialMediaRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
            }

            public async Task<UserSocialMediaModel> Handle(GetListUserSocialMediaByUserIdQuery request, CancellationToken cancellationToken)
            {
                var models = await _userSocialMediaRepository.GetListAsync(x => x.UserId == _sharedIdentityService.GetUserId
                                                                           , include: x => x.Include(u => u.SocialMedia));
                var mappedModels = _mapper.Map<UserSocialMediaModel>(models);
                return mappedModels;
            }
        }
    }
}
