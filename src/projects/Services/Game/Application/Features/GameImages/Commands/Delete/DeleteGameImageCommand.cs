using Application.Features.GameImages.DTOs;
using Application.Features.Games.DTOs;
using Application.Features.Games.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistance.Images;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GameImages.Commands.Delete
{
    public class DeleteGameImageCommand:IRequest<DeletedGameImageDto>
    {
        public int GameId { get; set; }
        public class DeleteGameImageCommandHandler : IRequestHandler<DeleteGameImageCommand, DeletedGameImageDto>
        {
            private ImageService _imageService;
            private IGameImageRepository _gameImageRepository;
            private IMapper _mapper;
            

            public DeleteGameImageCommandHandler(ImageService imageService, IGameImageRepository gameImageRepository, IMapper mapper)
            {
                _imageService = imageService;
                _gameImageRepository = gameImageRepository;
                _mapper = mapper;
               
            }

            public async Task<DeletedGameImageDto> Handle(DeleteGameImageCommand request, CancellationToken cancellationToken)
            {
                var getId = await _gameImageRepository.GetAsync(x => x.GameId == request.GameId);
                _imageService.DeleteFile(getId.ImagePath);
                await _gameImageRepository.DeleteAsync(getId);

                var result = _mapper.Map<DeletedGameImageDto>(getId);
                return result;
            }
        }
    }
}
