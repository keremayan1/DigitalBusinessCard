using Application.Features.SocialMedias.DTOs;
using Application.Services.Repositories;
using Application.Services.SocialMediaImages;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Core.Persistance.Images;
using Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.SocialMedias.Commands.Add
{
    public class CreateSocialMediaCommand : IRequest<CreatedSocialMediaDto>, ISecuredRequest
    {

        public string SocialMediaName { get; set; }
        public IFormFile Image { get; set; }

        public string[] Roles => new[] { Permissions.Admin, Permissions.Moderator };

        public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, CreatedSocialMediaDto>
        {
            private ISocialMediaRepository _socialMediaRepository;
            private IMapper _mapper;
            private ISocialMediaImageService _socialMediaImageService;

            public CreateSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper, ISocialMediaImageService socialMediaImageService)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
                _socialMediaImageService = socialMediaImageService;
            }

            public async Task<CreatedSocialMediaDto> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                var mappedModels = _mapper.Map<SocialMedia>(request);

                await _socialMediaRepository.AddAsync(mappedModels);
                await _socialMediaImageService.AddSocialMediaImage(new SocialMediaImage { SocialMediaId = mappedModels.Id }, request.Image, cancellationToken);

                var result = _mapper.Map<CreatedSocialMediaDto>(mappedModels);
                return result;
            }
        }
    }
}
