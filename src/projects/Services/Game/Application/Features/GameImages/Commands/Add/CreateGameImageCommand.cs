using Application.Features.GameImages.DTOs;
using Application.Features.GameImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using Core.Persistance.Images;
using Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GameImages.Commands.Add
{
    public class CreateGameImageCommand:IRequest<CreatedGameImageDto>,ISecuredRequest
    {
        public int GameId { get; set; }
        public IFormFile Photo { get; set; }
        public string[] Roles => new[] { Permissions.Admin };
        public class CreateGameImageCommandHandler : IRequestHandler<CreateGameImageCommand, CreatedGameImageDto>
        {
            private ImageService _imageService;
            private IGameImageRepository _gameImageRepository;
            private IMapper _mapper;
            private GameImageBusinessRules _gameImageBusinessRules;

            public CreateGameImageCommandHandler(ImageService imageService, IGameImageRepository gameImageRepository, IMapper mapper, GameImageBusinessRules gameImageBusinessRules)
            {
                _imageService = imageService;
                _gameImageRepository = gameImageRepository;
                _mapper = mapper;
                _gameImageBusinessRules = gameImageBusinessRules;
            }

            public async Task<CreatedGameImageDto> Handle(CreateGameImageCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<GameImage>(request);
                await _gameImageBusinessRules.CheckIfGameIdExists(mappedModel.GameId);
               
                var uploadFile = await _imageService.UploadFile(request.Photo, cancellationToken);
                mappedModel.ImagePath = uploadFile;
                mappedModel.Date = DateTime.Now;

                await _gameImageRepository.AddAsync(mappedModel);

                var result = _mapper.Map<CreatedGameImageDto>(mappedModel);
                return result;

                 
            }
        }
    }

}
