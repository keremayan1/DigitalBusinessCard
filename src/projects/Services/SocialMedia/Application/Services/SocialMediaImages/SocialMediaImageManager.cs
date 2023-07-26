using Application.Services.Repositories;
using Core.Persistance.Images;
using Domain.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.SocialMediaImages
{
    public class SocialMediaImageManager : ISocialMediaImageService
    {
        private ISocialMediaImageRepository _socialMediaImageRepository;
        private ImageService _imageService;

        public SocialMediaImageManager(ISocialMediaImageRepository socialMediaImageRepository, ImageService imageService)
        {
            _socialMediaImageRepository = socialMediaImageRepository;
            _imageService = imageService;
        }

        public async Task<SocialMediaImage> AddSocialMediaImage(SocialMediaImage image, IFormFile formFile, CancellationToken cancellationToken)
        {
            var uploadFile = await _imageService.UploadFile(formFile, cancellationToken);
            image.ImagePath = uploadFile;
            image.Date = DateTime.Now;
            var result = await _socialMediaImageRepository.AddAsync(image);

            return result;
        }

        public async Task<SocialMediaImage> DeleteSocialMediaImage(int socialMediaId)
        {
            var getId = await _socialMediaImageRepository.GetAsync(x => x.SocialMediaId == socialMediaId);
            _imageService.DeleteFile(getId.ImagePath);
            await _socialMediaImageRepository.DeleteAsync(getId);
            return getId;


        }

        public async Task<SocialMediaImage> UpdateSocialMediaImage(SocialMediaImage image, IFormFile formFile, CancellationToken cancellationToken)
        {
            var getId = await _socialMediaImageRepository.GetAsync(x => x.SocialMediaId == image.SocialMediaId);
            _imageService.DeleteFile(getId.ImagePath);

            var addPhoto = await _imageService.UploadFile(formFile, cancellationToken);
            getId.ImagePath = addPhoto;
            getId.Date = DateTime.Now;

            var result = await _socialMediaImageRepository.UpdateAsync(getId);
            return result;
        }
    }
}
