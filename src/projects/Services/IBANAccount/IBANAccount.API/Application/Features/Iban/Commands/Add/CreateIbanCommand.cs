using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using IBANAccount.API.Application.Features.Iban.DTOs;
using IBANAccount.API.Application.Features.Iban.Rules;
using IBANAccount.API.Application.Services.IbanImages;
using IBANAccount.API.Application.Services.Repositories;
using IBANAccount.API.Domain.Entities;
using IBANAccount.API.Persistance.Repositories;
using MediatR;

namespace IBANAccount.API.Application.Features.Iban.Commands.Add
{
    public class CreateIbanCommand:IRequest<CreatedIbanDto>,ISecuredRequest
    {
        public string Country { get; set; }
        public int Length { get; set; }
        public string Code { get; set; }
        public IFormFile Image { get; set; }

        public string[] Roles => new[] { Permissions.Admin };

        public class CreateIbanCommandHandler : IRequestHandler<CreateIbanCommand, CreatedIbanDto>
        {
            private IIbanRepository _ibanRepository;
            private IMapper _mapper;
            private IbanImageService _ibanImageService;
            private IbanBusinessRules _ibanBusinessRules;

            public CreateIbanCommandHandler(IIbanRepository ibanRepository, IMapper mapper, IbanImageService ibanImageService, IbanBusinessRules ibanBusinessRules)
            {
                _ibanRepository = ibanRepository;
                _mapper = mapper;
                _ibanImageService = ibanImageService;
                _ibanBusinessRules = ibanBusinessRules;
            }

            public async Task<CreatedIbanDto> Handle(CreateIbanCommand request, CancellationToken cancellationToken)
            {
                var mappedModel = _mapper.Map<Domain.Entities.Iban>(request);
                _ibanBusinessRules.ToUpper(mappedModel);
                _ibanBusinessRules.Trim(mappedModel);
                await _ibanRepository.AddAsync(mappedModel);
                await _ibanImageService.AddIbanImage(new IbanImage { IbanId = mappedModel.Id }, request.Image, cancellationToken);

                var result = _mapper.Map<CreatedIbanDto>(mappedModel);
                return result;
            }
        }
    }
}
