using Domain.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.GameImages
{
    public interface IGameImageService
    {
        Task<GameImage> AddGameImage(GameImage image, IFormFile formFile, CancellationToken cancellationToken);
           
        Task<GameImage> UpdateGameImage(GameImage image, IFormFile formFile, CancellationToken cancellationToken); 
        Task<GameImage> DeleteGameImage(int id);
    }
}
