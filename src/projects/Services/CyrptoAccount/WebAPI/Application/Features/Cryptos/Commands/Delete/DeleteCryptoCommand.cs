using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using MediatR;
using WebAPI.Application.Features.Cryptos.DTOs;
using WebAPI.Application.Services.CryptoImages;
using WebAPI.Application.Services.Repositories;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Features.Cryptos.Commands.Delete
{
    public class DeleteCryptoCommand : IRequest<DeletedCryptoDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { Permissions.Admin, Permissions.Moderator };

        public class DeleteCryptoCommandHandler : IRequestHandler<DeleteCryptoCommand, DeletedCryptoDto>
        {
            private ICryptoRepository _cryptoRepository;
            private IMapper _mapper;
            private ICryptoImageService _cryptoImageService;

            public DeleteCryptoCommandHandler(ICryptoRepository cryptoRepository, IMapper mapper, ICryptoImageService cryptoImageService)
            {
                _cryptoRepository = cryptoRepository;
                _mapper = mapper;
                _cryptoImageService = cryptoImageService;
            }

            public async Task<DeletedCryptoDto> Handle(DeleteCryptoCommand request, CancellationToken cancellationToken)
            {
                var getId = await _cryptoRepository.GetAsync(x => x.Id == request.Id);
                
                
                await _cryptoRepository.DeleteAsync(getId);
                await _cryptoImageService.DeleteCryptoImage(getId.Id);

                var result = _mapper.Map<DeletedCryptoDto>(getId);
                return result;
            }
        }
    }
}
