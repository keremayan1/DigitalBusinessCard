using Application.Features.SocialMedias.DTOs;
using Application.Features.UserSocialMedias.DTOs;
using Application.Features.UserSocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Core.Shared.Services;
using Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedias.Commands.Update
{
    public class UpdateUserSocialMediaCommand:IRequest<UpdatedUserSocialMediaDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public int SocialMediaId { get; set; }
        public string SocialMediaUrl { get; set; }
        public string[] Roles => new[] { Permissions.Admin, Permissions.User, Permissions.Moderator };
        public class UpdateUserSocialMediaCommandHandler : IRequestHandler<UpdateUserSocialMediaCommand, UpdatedUserSocialMediaDto>
        {
            private IUserSocialMediaRepository _userSocialMediaRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;
            private UserSocialMediaBusinessRules _userSocialMediaBusinessRules;
            public UpdateUserSocialMediaCommandHandler(IUserSocialMediaRepository userSocialMediaRepository, IMapper mapper, ISharedIdentityService sharedIdentityService, UserSocialMediaBusinessRules userSocialMediaBusinessRules)
            {
                _userSocialMediaRepository = userSocialMediaRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
                _userSocialMediaBusinessRules = userSocialMediaBusinessRules;
            }

            public async Task<UpdatedUserSocialMediaDto> Handle(UpdateUserSocialMediaCommand request, CancellationToken cancellationToken)
            {
                
                var mappedModel = _mapper.Map<UserSocialMedia>(request);
               await _userSocialMediaBusinessRules.CheckIfUserSocialMediaIdWhenUpdated(request.Id);
               
                mappedModel.UserId = _sharedIdentityService.GetUserId;

                await _userSocialMediaRepository.UpdateAsync(mappedModel);

                var result = _mapper.Map<UpdatedUserSocialMediaDto>(mappedModel);
                return result;
            }
        }
    }
}
