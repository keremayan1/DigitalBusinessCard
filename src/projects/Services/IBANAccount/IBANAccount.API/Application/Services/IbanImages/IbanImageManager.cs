using Core.Persistance.Images;
using IBANAccount.API.Application.Services.Repositories;
using IBANAccount.API.Domain.Entities;

namespace IBANAccount.API.Application.Services.IbanImages
{
    public class IbanImageManager : IbanImageService
    {
        private IIbanImageRepository _ibanImageRepository;
        private ImageService _imageService;

        public IbanImageManager(IIbanImageRepository ibanImageRepository, ImageService imageService)
        {
            _ibanImageRepository = ibanImageRepository;
            _imageService = imageService;
        }

        public async Task<IbanImage> AddIbanImage(IbanImage image, IFormFile formFile, CancellationToken cancellationToken)
        {
            var uploadFile = await _imageService.UploadFile(formFile, cancellationToken);
            image.ImagePath = uploadFile;
            image.Date = DateTime.Now;
            var result = await _ibanImageRepository.AddAsync(image);

            return result;
        }

        public async Task<IbanImage> DeleteIbanImage(int ibanId)
        {
            var getId = await _ibanImageRepository.GetAsync(x => x.IbanId == ibanId);
            _imageService.DeleteFile(getId.ImagePath);
            await _ibanImageRepository.DeleteAsync(getId);
            return getId;
        }

        public async Task<IbanImage> UpdateIbanImage(IbanImage image, IFormFile formFile, CancellationToken cancellationToken)
        {
            var getId = await _ibanImageRepository.GetAsync(x => x.IbanId == image.IbanId);
            _imageService.DeleteFile(getId.ImagePath);

            var addPhoto = await _imageService.UploadFile(formFile, cancellationToken);
            getId.ImagePath = addPhoto;
            getId.Date = DateTime.Now;

            var result = await _ibanImageRepository.UpdateAsync(getId);
            return result;
        }
    }
}
