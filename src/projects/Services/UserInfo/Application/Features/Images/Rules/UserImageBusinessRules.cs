using Application.Features.Images.Constants;
using Application.Services.Repositories;
using Core.Persistance.Images;
using Core.Shared.Services;
using Domain.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Images.Rules
{
    public class UserImageBusinessRules
    {
        private IUserImageRepository _userImageRepository;
        private ISharedIdentityService _sharedIdentityService;
        private ImageService _imageService;
        public UserImageBusinessRules(IUserImageRepository userImageRepository, ISharedIdentityService sharedIdentityService, ImageService imageService)
        {
            _userImageRepository = userImageRepository;
            _sharedIdentityService = sharedIdentityService;
            _imageService = imageService;
        }

        public async Task AddDefaultImage(UserImage userImage)
        {
            var result = await _userImageRepository.GetListAsync(x => x.UserId == _sharedIdentityService.GetUserId);
            if (result.Count==0)
            {
                await _userImageRepository.AddAsync(new UserImage
                {
                    UserId = _sharedIdentityService.GetUserId,
                    ImagePath = UserImageConstants.DefaultImagePath,
                    Date = DateTime.Now
                });
            }
        }
    }
}
