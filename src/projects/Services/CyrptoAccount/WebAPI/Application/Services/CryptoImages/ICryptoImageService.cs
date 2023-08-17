using WebAPI.Domain.Entities;

namespace WebAPI.Application.Services.CryptoImages
{
    public interface ICryptoImageService
    {
        Task<CryptoImage> AddCryptoImage(CryptoImage image, IFormFile formFile, CancellationToken cancellationToken);

        Task<CryptoImage> UpdateCryptoImage(CryptoImage image, IFormFile formFile, CancellationToken cancellationToken);
        Task<CryptoImage> DeleteCryptoImage(int id);
    }
}
