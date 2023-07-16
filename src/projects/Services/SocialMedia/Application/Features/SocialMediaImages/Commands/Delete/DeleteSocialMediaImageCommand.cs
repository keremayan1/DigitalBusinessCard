using Application.Features.SocialMediaImages.DTOs;
using Application.Features.SocialMediaImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistance.Images;
using MediatR;

namespace Application.Features.SocialMediaImages.Commands.Delete
{
    public class DeleteSocialMediaImageCommand : IRequest<DeletedSocialMediaImageDto>
    {
        public int SocialMediaId { get; set; }
        public class DeleteSocialMediaImageCommandHandler : IRequestHandler<DeleteSocialMediaImageCommand, DeletedSocialMediaImageDto>
        {
            private ImageService _imageService;
            private ISocialMediaImageRepository _socialMediaImageRepository;
            private IMapper _mapper;
            private SocialMediaImageBusinessRules _socialMediaImageBusinessRules;
            public DeleteSocialMediaImageCommandHandler(ImageService imageService, ISocialMediaImageRepository socialMediaImageRepository, IMapper mapper, SocialMediaImageBusinessRules socialMediaImageBusinessRules)
            {
                _imageService = imageService;
                _socialMediaImageRepository = socialMediaImageRepository;
                _mapper = mapper;
                _socialMediaImageBusinessRules = socialMediaImageBusinessRules;
            }
            public async Task<DeletedSocialMediaImageDto> Handle(DeleteSocialMediaImageCommand request, CancellationToken cancellationToken)
            {
                var getId = await _socialMediaImageRepository.GetAsync(x => x.SocialMediaId == request.SocialMediaId);
                _imageService.DeleteFile(getId.ImagePath);
                await _socialMediaImageRepository.DeleteAsync(getId);

                var result = _mapper.Map<DeletedSocialMediaImageDto>(getId);
                return result;

            }
        }
    }
}
