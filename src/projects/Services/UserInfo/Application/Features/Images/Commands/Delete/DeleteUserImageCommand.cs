using Application.Features.Images.Constants;
using Application.Features.Images.DTOs;
using Application.Features.Images.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistance.Images;
using Core.Shared.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Images.Commands.Delete
{
    public class DeleteUserImageCommand:IRequest<DeletedUserImageDto>
    {
        public int Id { get; set; }
        public class DeleteUserImageCommandHandler : IRequestHandler<DeleteUserImageCommand, DeletedUserImageDto>
        {
            private IUserImageRepository _userImageRepository;
            private ISharedIdentityService _sharedIdentityService;
            private ImageService _imageService;
            private IMapper _mapper;
            private UserImageBusinessRules _userImageBusinessRules;

            public DeleteUserImageCommandHandler(IUserImageRepository userImageRepository, ISharedIdentityService sharedIdentityService, ImageService imageService, IMapper mapper, UserImageBusinessRules userImageBusinessRules)
            {
                _userImageRepository = userImageRepository;
                _sharedIdentityService = sharedIdentityService;
                _imageService = imageService;
                _mapper = mapper;
                _userImageBusinessRules = userImageBusinessRules;
            }

            public async Task<DeletedUserImageDto> Handle(DeleteUserImageCommand request, CancellationToken cancellationToken)
            {
                var getId = await _userImageRepository.GetAsync(x => x.UserId == _sharedIdentityService.GetUserId);
                _imageService.DeleteFile(getId.ImagePath);
                await _userImageRepository.DeleteAsync(getId);

                await _userImageBusinessRules.AddDefaultImage(getId);
               
                var result = _mapper.Map<DeletedUserImageDto>(getId);
                return result;



            }
        }
    }
}
