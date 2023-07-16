using Application.Features.SocialMedias.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Commands.Delete
{
    public class DeleteSocialMediaCommand:IRequest<DeletedSocialMediaDto>
    {
        public int Id { get; set; }
        public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand, DeletedSocialMediaDto>
        {
            private ISocialMediaRepository _socialMediaRepository;
            private IMapper _mapper;

            public DeleteSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
            }

            public async Task<DeletedSocialMediaDto> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
            {
                var getId = await _socialMediaRepository.GetAsync(x => x.Id==request.Id);
                await _socialMediaRepository.DeleteAsync(getId);
                var result = _mapper.Map<DeletedSocialMediaDto>(getId);
                return result;

            }
        }
    }
}
