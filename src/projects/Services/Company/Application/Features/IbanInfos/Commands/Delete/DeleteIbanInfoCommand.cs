using Application.Features.IbanInfos.DTOs;
using Application.Services.IbanInfoImageService;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.IbanInfos.Commands.Delete
{
    public class DeleteIbanInfoCommand : IRequest<DeletedIbanInfoDto>
    {
        public int Id { get; set; }
        public class DeleteIbanInfoCommandHandler : IRequestHandler<DeleteIbanInfoCommand, DeletedIbanInfoDto>
        {
            private IIbanInfoRepository _ibanInfoRepository;
            private IMapper _mapper;
            private IIbanInfoImageService _ibanAccountImageService;

            public DeleteIbanInfoCommandHandler(IIbanInfoRepository ibanInfoRepository, IMapper mapper, IIbanInfoImageService ibanAccountImageService)
            {
                _ibanInfoRepository = ibanInfoRepository;
                _mapper = mapper;
                _ibanAccountImageService = ibanAccountImageService;
            }

            public async Task<DeletedIbanInfoDto> Handle(DeleteIbanInfoCommand request, CancellationToken cancellationToken)
            {
                var getId = await _ibanInfoRepository.GetAsync(x => x.Id == request.Id);
                await _ibanAccountImageService.DeleteIbanInfoImage(getId.Id);
                await _ibanInfoRepository.DeleteAsync(getId);
                var result = _mapper.Map<DeletedIbanInfoDto>(getId);
                return result;
            }
        }
    }
}
