using Application.Features.SocialMedias.DTOs;
using Application.Services.Repositories;
using Application.Services.SocialMediaImages;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Commands.Update
{
    public class UpdateSocialMediaCommand : IRequest<UpdatedSocialMediaDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string SocialMediaName { get; set; }
        public IFormFile Image { get; set; }
        public string[] Roles => new[] { Permissions.Admin, Permissions.Moderator };
        public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, UpdatedSocialMediaDto>
        {
            private ISocialMediaRepository _socialMediaRepository;
            private IMapper _mapper;
            private ISocialMediaImageService _socialMediaImageService;

            public UpdateSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper, ISocialMediaImageService socialMediaImageService)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
                _socialMediaImageService = socialMediaImageService;
            }

            public async Task<UpdatedSocialMediaDto> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<SocialMedia>(request);
                await _socialMediaRepository.UpdateAsync(mappedModel);
                await _socialMediaImageService.UpdateSocialMediaImage(new SocialMediaImage { SocialMediaId = mappedModel.Id }, request.Image, cancellationToken);
                var result = _mapper.Map<UpdatedSocialMediaDto>(mappedModel);
                return result;

            }
        }
    }
}
