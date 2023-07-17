using Application.Features.SocialMedias.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Commands.Update
{
    public class UpdateSocialMediaCommand : IRequest<UpdatedSocialMediaDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string SocialMediaName { get; set; }
        public string[] Roles => new[] { Permissions.Admin, Permissions.Moderator };
        public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, UpdatedSocialMediaDto>
        {
            private ISocialMediaRepository _socialMediaRepository;
            private IMapper _mapper;

            public UpdateSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedSocialMediaDto> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<SocialMedia>(request);
                await _socialMediaRepository.UpdateAsync(mappedModel);
                var result = _mapper.Map<UpdatedSocialMediaDto>(mappedModel);
                return result;

            }
        }
    }
}
