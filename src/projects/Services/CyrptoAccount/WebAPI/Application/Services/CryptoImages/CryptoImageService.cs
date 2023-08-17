using Core.Persistance.Images;
using WebAPI.Application.Services.Repositories;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Services.CryptoImages
{
    public class CryptoImageService : ICryptoImageService
    {
        private ICryptoImageRepository _cryptoImageRepository;
        private ImageService _imageService;

        public CryptoImageService(ICryptoImageRepository cryptoImageRepository, ImageService imageService)
        {
            _cryptoImageRepository = cryptoImageRepository;
            _imageService = imageService;
        }

        public async Task<CryptoImage> AddCryptoImage(CryptoImage image, IFormFile formFile, CancellationToken cancellationToken)
        {
            var uploadFile = await _imageService.UploadFile(formFile, cancellationToken);
            image.ImagePath = uploadFile;
            image.Date = DateTime.Now;
            var result = await _cryptoImageRepository.AddAsync(image);
            return result;
        }

        public async Task<CryptoImage> DeleteCryptoImage(int cryptoId)
        {
            var getId = await _cryptoImageRepository.GetAsync(x => x.CryptoId == cryptoId);
            _imageService.DeleteFile(getId.ImagePath);
            await _cryptoImageRepository.DeleteAsync(getId);
            return getId;
        }

        public async Task<CryptoImage> UpdateCryptoImage(CryptoImage image, IFormFile formFile, CancellationToken cancellationToken)
        {
            var getId= await _cryptoImageRepository.GetAsync(x=>x.CryptoId==image.CryptoId);
            _imageService.DeleteFile(getId.ImagePath);

            var addPhoto = await _imageService.UploadFile(formFile, cancellationToken);
            getId.ImagePath = addPhoto;
            getId.Date = DateTime.Now;

            var result = await _cryptoImageRepository.UpdateAsync(getId);
            return result;
        }
    }
}
