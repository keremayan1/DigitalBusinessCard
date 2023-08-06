using IBANAccount.API.Domain.Entities;

namespace IBANAccount.API.Application.Services.IbanImages
{
    public interface IbanImageService
    {
        Task<IbanImage> AddIbanImage(IbanImage image, IFormFile formFile, CancellationToken cancellationToken);
        Task<IbanImage> UpdateIbanImage(IbanImage image, IFormFile formFile, CancellationToken cancellationToken);
        Task<IbanImage> DeleteIbanImage(int id);
    }
}
