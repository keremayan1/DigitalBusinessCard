﻿
using Microsoft.AspNetCore.Http;

namespace Core.Persistance.Images.Concrete
{
    public class ImageManager : ImageService
    {

        public string DeleteFile(string photoUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", photoUrl);
            if (!File.Exists(path))
            {
                return "photo not found";
            }

            File.Delete(path);

            return "Başarıyla Silindi!";
        }

        public async Task<string> UploadFile(IFormFile photo, CancellationToken cancellationToken)
        {

            if (photo != null && photo.Length > 0)
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using var stream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(stream, cancellationToken);
                var returnPath = fileName;
                return returnPath;
            }
            return "photo is empty";
        }

    }
}
