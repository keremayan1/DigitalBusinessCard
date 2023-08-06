using AutoMapper;
using Core.Application.Constants;
using Core.Application.Pipelines.Authorization;
using IBANAccount.API.Application.Features.Iban.DTOs;
using IBANAccount.API.Application.Services.IbanImages;
using IBANAccount.API.Application.Services.Repositories;
using IBANAccount.API.Domain.Entities;
using MediatR;

namespace IBANAccount.API.Application.Features.Iban.Commands.Delete
{
    public class DeleteIbanCommand : IRequest<DeletedIbanDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public int Length { get; set; }
        public string Code { get; set; }
        public IFormFile Image { get; set; }

        public string[] Roles => new[] { Permissions.Admin };

        public class DeleteIbanCommandHandler : IRequestHandler<DeleteIbanCommand, DeletedIbanDto>
        {
            private IIbanRepository _ibanRepository;
            private IMapper _mapper;
            private IbanImageService _ibanImageService;

            public DeleteIbanCommandHandler(IIbanRepository ibanRepository, IMapper mapper, IbanImageService ibanImageService)
            {
                _ibanRepository = ibanRepository;
                _mapper = mapper;
                _ibanImageService = ibanImageService;
            }

            public async Task<DeletedIbanDto> Handle(DeleteIbanCommand request, CancellationToken cancellationToken)
            {
                var getId = await _ibanRepository.GetAsync(x => x.Id == request.Id);
                await _ibanImageService.DeleteIbanImage(getId.Id);
                await _ibanRepository.DeleteAsync(getId);

                var result = _mapper.Map<DeletedIbanDto>(getId);
                return result;
            }
        }
    }
}
