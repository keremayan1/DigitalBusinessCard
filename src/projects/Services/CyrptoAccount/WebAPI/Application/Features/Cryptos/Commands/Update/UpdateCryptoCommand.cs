using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using MediatR;
using WebAPI.Application.Features.Cryptos.Commands.Add;
using WebAPI.Application.Features.Cryptos.DTOs;
using WebAPI.Application.Services.CryptoImages;
using WebAPI.Application.Services.Repositories;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Features.Cryptos.Commands.Update
{
    public class UpdateCryptoCommand : IRequest<UpdatedCryptoDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string CryptoName { get; set; }
        public IFormFile Image { get; set; }
        public string[] Roles => new[] { Permissions.Admin, Permissions.Moderator };
        public class UpdateCryptoCommandHandler : IRequestHandler<UpdateCryptoCommand, UpdatedCryptoDto>
        {
            private ICryptoRepository _cryptoRepository;
            private IMapper _mapper;
            private ICryptoImageService _cryptoImageService;

            public UpdateCryptoCommandHandler(ICryptoRepository cryptoRepository, IMapper mapper, ICryptoImageService cryptoImageService)
            {
                _cryptoRepository = cryptoRepository;
                _mapper = mapper;
                _cryptoImageService = cryptoImageService;
            }

            public async Task<UpdatedCryptoDto> Handle(UpdateCryptoCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<Crypto>(request);

                await _cryptoRepository.UpdateAsync(mappedModel);
                await _cryptoImageService.UpdateCryptoImage(new CryptoImage { CryptoId = mappedModel.Id }, request.Image, cancellationToken);

                var result = _mapper.Map<UpdatedCryptoDto>(mappedModel);
                return result;
            }
        }
    }
}
