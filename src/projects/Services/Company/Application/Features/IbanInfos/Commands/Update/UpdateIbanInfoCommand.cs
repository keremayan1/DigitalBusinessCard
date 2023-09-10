using Application.Features.IbanInfos.DTOs;
using Application.Services.IbanInfoImageService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.IbanInfos.Commands.Update
{
    public class UpdateIbanInfoCommand : IRequest<UpdatedIbanInfoDto>
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public int Length { get; set; }
        public string Code { get; set; }
        public IFormFile Image { get; set; }
        public class UpdateIbanInfoCommandHandler : IRequestHandler<UpdateIbanInfoCommand, UpdatedIbanInfoDto>
        {
            private IIbanInfoRepository _ibanInfoRepository;
            private IMapper _mapper;
            private IIbanInfoImageService _ibanInfoImageService;

            public UpdateIbanInfoCommandHandler(IIbanInfoRepository ibanInfoRepository, IMapper mapper, IIbanInfoImageService ibanInfoImageService)
            {
                _ibanInfoRepository = ibanInfoRepository;
                _mapper = mapper;
                _ibanInfoImageService = ibanInfoImageService;
            }

            public async Task<UpdatedIbanInfoDto> Handle(UpdateIbanInfoCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<IbanInfo>(request);
                await _ibanInfoRepository.UpdateAsync(mappedModel);
                await _ibanInfoImageService.UpdateIbanInfoImage(new IbanInfoImage
                { IbanInfoId = mappedModel.Id }, request.Image, cancellationToken);
                var result = _mapper.Map<UpdatedIbanInfoDto>(mappedModel);
                return result;
            }
        }
    }
}
