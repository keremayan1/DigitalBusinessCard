using Application.Services.CompanyImageService;
using Application.Services.Repositories;
using Core.Persistance.Images;
using Domain.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IbanInfoImageService
{
    public class IbanInfoImageManager : IIbanInfoImageService
    {
        private IIbanInfoImageRepository _bankIbanAccountImageRepository;
        private ImageService _imageService;

        public IbanInfoImageManager(IIbanInfoImageRepository bankIbanAccountImageRepository, ImageService imageService)
        {
            _bankIbanAccountImageRepository = bankIbanAccountImageRepository;
            _imageService = imageService;
        }

        public async Task<IbanInfoImage> AddIbanInfoImage(IbanInfoImage image, IFormFile formFile, CancellationToken cancellationToken)
        {
            var uploadFile = await _imageService.UploadFile(formFile, cancellationToken);
            image.ImagePath = uploadFile;
            image.Date = DateTime.Now;
            var result = await _bankIbanAccountImageRepository.AddAsync(image);

            return result;
        }

        public async Task<IbanInfoImage> DeleteIbanInfoImage(int bankIbanAccountId)
        {
            var getId = await _bankIbanAccountImageRepository.GetAsync(x => x.IbanInfoId == bankIbanAccountId);
            _imageService.DeleteFile(getId.ImagePath);
            await _bankIbanAccountImageRepository.DeleteAsync(getId);
            return getId;


        }

        public async Task<IbanInfoImage> UpdateIbanInfoImage(IbanInfoImage image, IFormFile formFile, CancellationToken cancellationToken)
        {
            var getId = await _bankIbanAccountImageRepository.GetAsync(x => x.IbanInfoId == image.IbanInfoId);
            _imageService.DeleteFile(getId.ImagePath);

            var addPhoto = await _imageService.UploadFile(formFile, cancellationToken);
            getId.ImagePath = addPhoto;
            getId.Date = DateTime.Now;

            var result = await _bankIbanAccountImageRepository.UpdateAsync(getId);
            return result;
        }
    }
}
