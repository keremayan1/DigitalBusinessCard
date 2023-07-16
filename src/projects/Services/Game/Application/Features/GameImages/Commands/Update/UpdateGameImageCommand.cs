using Application.Features.GameImages.DTOs;
using Application.Features.GameImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistance.Images;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GameImages.Commands.Update
{
    public class UpdateGameImageCommand:IRequest<UpdatedGameImageDto>
    {
        public int GameId { get; set; }
        public IFormFile Photo { get; set; }
        public class UpdateGameImageCommandHandler : IRequestHandler<UpdateGameImageCommand, UpdatedGameImageDto>
        {
            private ImageService _imageService;
            private IGameImageRepository _gameImageRepository;
            private IMapper _mapper;
            private GameImageBusinessRules _gameImageBusinessRules;

            public UpdateGameImageCommandHandler(ImageService imageService, IGameImageRepository gameImageRepository, IMapper mapper, GameImageBusinessRules gameImageBusinessRules)
            {
                _imageService = imageService;
                _gameImageRepository = gameImageRepository;
                _mapper = mapper;
                _gameImageBusinessRules = gameImageBusinessRules;
            }

            public async Task<UpdatedGameImageDto> Handle(UpdateGameImageCommand request, CancellationToken cancellationToken)
            {
                await _gameImageBusinessRules.CheckIfGameIdIsNull(request.GameId);

                var getId = await _gameImageRepository.GetAsync(x=>x.GameId==request.GameId);
                _imageService.DeleteFile(getId.ImagePath);

                var addPhoto = await _imageService.UploadFile(request.Photo, cancellationToken);
                getId.ImagePath = addPhoto;
                getId.Date = DateTime.Now;

                await _gameImageRepository.UpdateAsync(getId);

                var response = _mapper.Map<UpdatedGameImageDto>(getId);
                return response;
            }
        }
    }
}
