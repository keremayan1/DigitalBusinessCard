using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using IBANAccount.API.Application.Features.Iban.DTOs;
using IBANAccount.API.Application.Features.Iban.Rules;
using IBANAccount.API.Application.Services.IbanImages;
using IBANAccount.API.Application.Services.Repositories;
using IBANAccount.API.Domain.Entities;
using MediatR;

namespace IBANAccount.API.Application.Features.Iban.Commands.Update
{
    public class UpdateIbanCommand : IRequest<UpdatedIbanDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public int Length { get; set; }
        public string Code { get; set; }
        public IFormFile Image { get; set; }

        public string[] Roles => new[] { Permissions.Admin };
        public class UpdateIbanCommandHandler : IRequestHandler<UpdateIbanCommand, UpdatedIbanDto>
        {
            private IIbanRepository _ibanRepository;
            private IMapper _mapper;
            private IbanImageService _ibanImageService;
            private IbanBusinessRules _ibanBusinessRules;
            public UpdateIbanCommandHandler(IIbanRepository ibanRepository, IMapper mapper, IbanImageService ibanImageService, IbanBusinessRules ibanBusinessRules)
            {
                _ibanRepository = ibanRepository;
                _mapper = mapper;
                _ibanImageService = ibanImageService;
                _ibanBusinessRules = ibanBusinessRules;
            }

            public async Task<UpdatedIbanDto> Handle(UpdateIbanCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<Domain.Entities.Iban>(request);
                _ibanBusinessRules.ToUpper(mappedModel);
                _ibanBusinessRules.Trim(mappedModel);
                await _ibanRepository.UpdateAsync(mappedModel);
                await _ibanImageService.UpdateIbanImage(new IbanImage { IbanId = mappedModel.Id }, request.Image, cancellationToken);
                var result = _mapper.Map<UpdatedIbanDto>(mappedModel);
                return result;
            }
        }
    }
}
