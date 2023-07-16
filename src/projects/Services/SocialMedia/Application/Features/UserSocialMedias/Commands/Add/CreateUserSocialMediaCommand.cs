using Application.Features.UserSocialMedias.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Core.Shared.Services;
using Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedias.Commands.Add
{
    public class CreateUserSocialMediaCommand:IRequest<CreatedUserSocialMediaDto>
    {
        public int SocialMediaId { get; set; }
        public string SocialMediaUrl { get; set; }
        
        public class CreateUserSocialMediaCommandHandler : IRequestHandler<CreateUserSocialMediaCommand, CreatedUserSocialMediaDto>
        {
            private IUserSocialMediaRepository _userSocialMediaRepository;
            private IMapper _mapper;
            private ISharedIdentityService _sharedIdentityService;

            public CreateUserSocialMediaCommandHandler(IUserSocialMediaRepository userSocialMediaRepository, IMapper mapper, ISharedIdentityService sharedIdentityService)
            {
                _userSocialMediaRepository = userSocialMediaRepository;
                _mapper = mapper;
                _sharedIdentityService = sharedIdentityService;
            }

            public async Task<CreatedUserSocialMediaDto> Handle(CreateUserSocialMediaCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<UserSocialMedia>(request);
                mappedModel.UserId = _sharedIdentityService.GetUserId;
                await _userSocialMediaRepository.AddAsync(mappedModel);

                var result = _mapper.Map<CreatedUserSocialMediaDto>(mappedModel);
                return result;
            }
        }
    }
}
