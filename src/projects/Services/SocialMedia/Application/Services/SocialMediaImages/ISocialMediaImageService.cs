using Domain.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.SocialMediaImages
{
    public interface ISocialMediaImageService
    {
        Task<SocialMediaImage> AddSocialMediaImage(SocialMediaImage image, IFormFile formFile, CancellationToken cancellationToken);

        Task<SocialMediaImage> UpdateSocialMediaImage(SocialMediaImage image, IFormFile formFile, CancellationToken cancellationToken);
        Task<SocialMediaImage> DeleteSocialMediaImage(int id);
    }
}
