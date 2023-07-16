
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistance.Images
{
    public interface ImageService
    {
        Task<string> UploadFile(IFormFile photo,CancellationToken cancellationToken);
        string DeleteFile(string photoUrl);
    }
}
