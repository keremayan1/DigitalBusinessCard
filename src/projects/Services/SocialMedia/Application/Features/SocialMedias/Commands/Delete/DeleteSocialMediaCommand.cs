using Application.Features.SocialMedias.DTOs;
using Application.Services.Repositories;
using Application.Services.SocialMediaImages;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Commands.Delete
{
    public class DeleteSocialMediaCommand:IRequest<DeletedSocialMediaDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { Permissions.Admin, Permissions.Moderator };
        public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand, DeletedSocialMediaDto>
        {
            private ISocialMediaRepository _socialMediaRepository;
            private IMapper _mapper;
            private ISocialMediaImageService _socialMediaImageService;

            public DeleteSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper, ISocialMediaImageService socialMediaImageService)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
                _socialMediaImageService = socialMediaImageService;
            }

            public async Task<DeletedSocialMediaDto> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
            {
                var getId = await _socialMediaRepository.GetAsync(x => x.Id==request.Id);
                await _socialMediaImageService.DeleteSocialMediaImage(getId.Id);
                await _socialMediaRepository.DeleteAsync(getId);
                var result = _mapper.Map<DeletedSocialMediaDto>(getId);
                return result;

            }
        }
    }
}
