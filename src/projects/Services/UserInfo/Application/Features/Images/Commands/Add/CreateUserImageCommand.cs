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

namespace Application.Features.Images.Commands.Add
{
    public class CreateUserImageCommand:IRequest<CreatedUserImageDto>
    {
        public IFormFile File { get; set; }
        public class CreateUserImageCommandHandler : IRequestHandler<CreateUserImageCommand, CreatedUserImageDto>
        {
            private IUserImageRepository _userImageRepository;
            private IMapper _mapper;
            private ImageService _imageService;
            private ISharedIdentityService _sharedIdentityService;
            public CreateUserImageCommandHandler(IUserImageRepository userImageRepository, IMapper mapper, ImageService imageService, ISharedIdentityService sharedIdentityService)
            {
                _userImageRepository = userImageRepository;
                _mapper = mapper;
                _imageService = imageService;
                _sharedIdentityService = sharedIdentityService;
            }

            public async Task<CreatedUserImageDto> Handle(CreateUserImageCommand request, CancellationToken cancellationToken)
            {
                var model = _mapper.Map<UserImage>(request);
                model.UserId = _sharedIdentityService.GetUserId;
                model.Date = DateTime.Now;
                var addImage = await _imageService.UploadFile(request.File, cancellationToken);
                model.ImagePath = addImage;

                await _userImageRepository.AddAsync(model);
                var result = _mapper.Map<CreatedUserImageDto>(model);
                return result;
            }
        }
    }
}
