using Application.Features.UserSocialMedias.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedias.Commands.Delete
{
    public class DeleteUserSocialMediaCommand:IRequest<DeletedUserSocialMediaDto>
    {
        public int Id { get; set; }
        public class DeleteUserSocialMediaCommandHandler : IRequestHandler<DeleteUserSocialMediaCommand, DeletedUserSocialMediaDto>
        {
            private IUserSocialMediaRepository _userSocialMediaRepository;
            private IMapper _mapper;

            public DeleteUserSocialMediaCommandHandler(IUserSocialMediaRepository userSocialMediaRepository, IMapper mapper)
            {
                _userSocialMediaRepository = userSocialMediaRepository;
                _mapper = mapper;
            }

            public async Task<DeletedUserSocialMediaDto> Handle(DeleteUserSocialMediaCommand request, CancellationToken cancellationToken)
            {
                var getId = await _userSocialMediaRepository.GetAsync(x => x.Id == request.Id);
                await _userSocialMediaRepository.DeleteAsync(getId);

                var result = _mapper.Map<DeletedUserSocialMediaDto>(getId);
                return result;
            }
        }
    }
}
