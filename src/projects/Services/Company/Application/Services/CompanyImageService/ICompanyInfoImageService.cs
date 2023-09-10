using Domain.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.CompanyImageService
{
    public interface ICompanyInfoImageService
    {
        Task<CompanyInfoImage> AddCompanyInfoImage(CompanyInfoImage image, IFormFile formFile, CancellationToken cancellationToken);

        Task<CompanyInfoImage> UpdateCompanyInfoImage(CompanyInfoImage image, IFormFile formFile, CancellationToken cancellationToken);
        Task<CompanyInfoImage> DeleteCompanyInfoImage(int id);
    }
}
