using Application.Features.IbanInfos.DTOs;
using Application.Services.IbanInfoImageService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.IbanInfos.Commands.Add
{
    public class CreateIbanInfoCommand : IRequest<CreatedIbanInfoDto>
    {
        public string Country { get; set; }
        public int Length { get; set; }
        public string Code { get; set; }
        public IFormFile Image { get; set; }
        public class CreateIbanInfoCommandHandler : IRequestHandler<CreateIbanInfoCommand, CreatedIbanInfoDto>
        {
            private IIbanInfoRepository _ibanInfoRepository;
            private IMapper _mapper;
            private IIbanInfoImageService _ibanAccountImageService;

            public CreateIbanInfoCommandHandler(IIbanInfoRepository ibanInfoRepository, IMapper mapper,
                IIbanInfoImageService ibanAccountImageService)
            {
                _ibanInfoRepository = ibanInfoRepository;
                _mapper = mapper;
                _ibanAccountImageService = ibanAccountImageService;
            }

            public async Task<CreatedIbanInfoDto> Handle(CreateIbanInfoCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<IbanInfo>(request);
                await _ibanInfoRepository.AddAsync(mappedModel);
                await _ibanAccountImageService.AddIbanInfoImage(new IbanInfoImage { IbanInfoId = mappedModel.Id }, request.Image, cancellationToken);
                var result = _mapper.Map<CreatedIbanInfoDto>(mappedModel);
                return result;
            }
        }
    }
}
