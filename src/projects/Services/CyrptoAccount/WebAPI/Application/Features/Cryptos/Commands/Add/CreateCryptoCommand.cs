using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using MediatR;
using WebAPI.Application.Features.Cryptos.DTOs;
using WebAPI.Application.Services.CryptoImages;
using WebAPI.Application.Services.Repositories;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Features.Cryptos.Commands.Add
{
    public class CreateCryptoCommand:IRequest<CreatedCryptoDto>,ISecuredRequest
    {
        public string CryptoName { get; set; }
        public IFormFile Image { get; set; }

        public string[] Roles => new[] { Permissions.Admin, Permissions.Moderator };

        public class CreateCryptoCommandHandler : IRequestHandler<CreateCryptoCommand, CreatedCryptoDto>
        {
            private ICryptoRepository _cryptoRepository;
            private IMapper _mapper;
            private ICryptoImageService _cryptoImageService;

            public CreateCryptoCommandHandler(ICryptoRepository cryptoRepository, IMapper mapper, ICryptoImageService cryptoImageService)
            {
                _cryptoRepository = cryptoRepository;
                _mapper = mapper;
                _cryptoImageService = cryptoImageService;
            }

            public async Task<CreatedCryptoDto> Handle(CreateCryptoCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<Crypto>(request);

                await _cryptoRepository.AddAsync(mappedModel);
                await _cryptoImageService.AddCryptoImage(new CryptoImage { CryptoId = mappedModel.Id }, request.Image, cancellationToken);

                var result = _mapper.Map<CreatedCryptoDto>(mappedModel);
                return result;
            }
        }
    }
}
