using Application.Features.Images.Constants;
using Application.Features.Images.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistance.Images;
using Core.Shared.Services;
using Domain.Concrete.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Images.Commands.Update
{
    public class UpdateUserImageCommand:IRequest<UpdatedUserImageDto>
    {
        public int Id { get; set; }
        public IFormFile File { get; set; }
        public class UpdateUserImageCommandHandler : IRequestHandler<UpdateUserImageCommand, UpdatedUserImageDto>
        {
            private ISharedIdentityService _sharedIdentityService;
            private IUserImageRepository _userImageRepository;
            private ImageService _imageService;
            private IMapper _mapper;

            public UpdateUserImageCommandHandler(ISharedIdentityService sharedIdentityService, IUserImageRepository userImageRepository, ImageService imageService, IMapper mapper)
            {
                _sharedIdentityService = sharedIdentityService;
                _userImageRepository = userImageRepository;
                _imageService = imageService;
                _mapper = mapper;
            }

            public async Task<UpdatedUserImageDto> Handle(UpdateUserImageCommand request, CancellationToken cancellationToken)
            {
                var result = await _userImageRepository.GetAsync(x => x.UserId == _sharedIdentityService.GetUserId);
                if (result != null)
                {
                    if (result.ImagePath!=UserImageConstants.DefaultImagePath)
                    {
                        _imageService.DeleteFile(result.ImagePath);
                    }
                    
                    var uploadFile = await _imageService.UploadFile(request.File, cancellationToken);
                    result.ImagePath = uploadFile;
                    result.Date = DateTime.Now;
                }
                
                await _userImageRepository.UpdateAsync(result);
                var response = _mapper.Map<UpdatedUserImageDto>(result);
                return response;
            }
        }
    }
}
