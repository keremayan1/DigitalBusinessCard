using Application.Features.SocialMediaImages.DTOs;
using Application.Features.SocialMediaImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistance.Images;
using Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.SocialMediaImages.Commands.Add
{
    public class CreateSocialMediaImageCommand:IRequest<CreatedSocialMediaImageDto>
    {
        public int SocialMediaId { get; set; }
        
        public IFormFile File { get; set; }
        public class CreateSocialMediaImageCommandHandler : IRequestHandler<CreateSocialMediaImageCommand, CreatedSocialMediaImageDto>
        {
            private ImageService _imageService;
            private ISocialMediaImageRepository _socialMediaImageRepository;
            private IMapper _mapper;
            private SocialMediaImageBusinessRules _socialMediaImageBusinessRules;
            public CreateSocialMediaImageCommandHandler(ImageService imageService, ISocialMediaImageRepository socialMediaImageRepository, IMapper mapper, SocialMediaImageBusinessRules socialMediaImageBusinessRules)
            {
                _imageService = imageService;
                _socialMediaImageRepository = socialMediaImageRepository;
                _mapper = mapper;
                _socialMediaImageBusinessRules = socialMediaImageBusinessRules;
            }

            public async Task<CreatedSocialMediaImageDto> Handle(CreateSocialMediaImageCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<SocialMediaImage>(request);
                await _socialMediaImageBusinessRules.CheckIfSocialMediaIdExists(mappedModel.SocialMediaId);
                var result2 =   await _imageService.UploadFile(request.File, cancellationToken);
                mappedModel.ImagePath = result2;
                mappedModel.Date = DateTime.Now;
                

                await _socialMediaImageRepository.AddAsync(mappedModel);
                
                var result = _mapper.Map<CreatedSocialMediaImageDto>(mappedModel);
                return result;

            }
        }
    }
}
