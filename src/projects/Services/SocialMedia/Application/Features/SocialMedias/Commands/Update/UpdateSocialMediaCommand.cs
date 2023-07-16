using Application.Features.SocialMedias.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Commands.Update
{
    public class UpdateSocialMediaCommand : IRequest<UpdatedSocialMediaDto>
    {
        public int Id { get; set; }
        public string SocialMediaName { get; set; }
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
