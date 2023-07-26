using Application.Services.Repositories;
using Core.Persistance.Images;
using Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.GameImages
{
    public class GameImageManager : IGameImageService
    {
        private IGameImageRepository _gameImageRepository;
        private ImageService _imageService;

        public GameImageManager(IGameImageRepository gameImageRepository, ImageService imageService)
        {
            _gameImageRepository = gameImageRepository;
            _imageService = imageService;
        }

        public async Task<GameImage> AddGameImage(GameImage image, IFormFile formFile,CancellationToken cancellationToken)
        {
            var uploadFile = await _imageService.UploadFile(formFile,cancellationToken);
            image.ImagePath = uploadFile;
            image.Date = DateTime.Now;
            var result = await _gameImageRepository.AddAsync(image);
            
            return result;
        }

        public async Task<GameImage> DeleteGameImage(int gameId)
        {
            var getId = await _gameImageRepository.GetAsync(x => x.GameId == gameId);
            _imageService.DeleteFile(getId.ImagePath);
            await _gameImageRepository.DeleteAsync(getId);
            return getId;


        }

        public async Task<GameImage> UpdateGameImage(GameImage image, IFormFile formFile,CancellationToken cancellationToken)
        {
            var getId = await _gameImageRepository.GetAsync(x => x.GameId == image.GameId);
            _imageService.DeleteFile(getId.ImagePath);

            var addPhoto = await _imageService.UploadFile(formFile, cancellationToken);
            getId.ImagePath = addPhoto;
            getId.Date = DateTime.Now;

            var result = await _gameImageRepository.UpdateAsync(getId);
            return result;
        }
    }
}
