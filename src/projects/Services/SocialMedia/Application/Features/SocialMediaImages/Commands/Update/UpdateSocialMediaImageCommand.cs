using Application.Features.SocialMediaImages.DTOs;
using Application.Features.SocialMediaImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Core.Persistance.Images;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.SocialMediaImages.Commands.Update
{
    public class UpdateSocialMediaImageCommand : IRequest<UpdatedSocialMediaImageDto>,ISecuredRequest
    {
        public int SocialMediaId { get; set; }
        public IFormFile File { get; set; }

        public string[] Roles => new[] { Permissions.Admin, Permissions.Moderator };

        public class UpdateSocialMediaImageCommandHandler : IRequestHandler<UpdateSocialMediaImageCommand, UpdatedSocialMediaImageDto>
        {
            private ImageService _imageService;
            private ISocialMediaImageRepository _socialMediaImageRepository;
            private IMapper _mapper;
            private SocialMediaImageBusinessRules _socialMediaImageBusinessRules;
            public UpdateSocialMediaImageCommandHandler(ImageService imageService, ISocialMediaImageRepository socialMediaImageRepository, IMapper mapper, SocialMediaImageBusinessRules socialMediaImageBusinessRules)
            {
                _imageService = imageService;
                _socialMediaImageRepository = socialMediaImageRepository;
                _mapper = mapper;
                _socialMediaImageBusinessRules = socialMediaImageBusinessRules;
            }

            public async Task<UpdatedSocialMediaImageDto> Handle(UpdateSocialMediaImageCommand request, CancellationToken cancellationToken)
            {
                await _socialMediaImageBusinessRules.CheckIfSocialMediaIdIsNull(request.SocialMediaId);
                              
                var getId = await _socialMediaImageRepository.GetAsync(x=>x.SocialMediaId == request.SocialMediaId);
                _imageService.DeleteFile(getId.ImagePath);

                var result = await _imageService.UploadFile(request.File, cancellationToken);
                getId.ImagePath = result;
                getId.Date = DateTime.Now;

                await _socialMediaImageRepository.UpdateAsync(getId);

                var response = _mapper.Map<UpdatedSocialMediaImageDto>(getId);
                return response;

            }
        }
    }

}
