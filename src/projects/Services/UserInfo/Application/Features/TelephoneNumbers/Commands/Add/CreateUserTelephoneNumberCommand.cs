using Application.Features.TelephoneNumbers.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Core.Shared.Services;
using Domain.Concrete.Entities;
using MediatR;

namespace Application.Features.TelephoneNumbers.Commands.Add
{
    public class CreateUserTelephoneNumberCommand : IRequest<CreatedUserTelephoneNumberDto>
    {
        public int UserTelephoneTypeId { get; set; }
        public int UserTelephoneCountryId { get; set; }
        public string TelephoneNumber { get; set; }
        public class CreateUserTelephoneNumberCommandHandler : IRequestHandler<CreateUserTelephoneNumberCommand, CreatedUserTelephoneNumberDto>
        {
            private IUserTelephoneNumberRepository _userTelephoneNumberRepository;
            private ISharedIdentityService _sharedIdentityService;
            private IMapper _mapper;

            public CreateUserTelephoneNumberCommandHandler(IUserTelephoneNumberRepository userTelephoneNumberRepository, ISharedIdentityService sharedIdentityService, IMapper mapper)
            {
                _userTelephoneNumberRepository = userTelephoneNumberRepository;
                _sharedIdentityService = sharedIdentityService;
                _mapper = mapper;
            }

            public async Task<CreatedUserTelephoneNumberDto> Handle(CreateUserTelephoneNumberCommand request, CancellationToken cancellationToken)
            {
                var model = _mapper.Map<UserTelephoneNumber>(request);
                model.UserId = _sharedIdentityService.GetUserId;
                await _userTelephoneNumberRepository.AddAsync(model);

                var result = _mapper.Map<CreatedUserTelephoneNumberDto>(model);
                return result;
            }
        }
    }
}
