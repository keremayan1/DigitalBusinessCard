using Domain.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.IbanInfoImageService
{
    public interface IIbanInfoImageService
    {
        Task<IbanInfoImage> AddIbanInfoImage(IbanInfoImage image, IFormFile formFile, CancellationToken cancellationToken);

        Task<IbanInfoImage> UpdateIbanInfoImage(IbanInfoImage image, IFormFile formFile, CancellationToken cancellationToken);
        Task<IbanInfoImage> DeleteIbanInfoImage(int id);
    }
}
