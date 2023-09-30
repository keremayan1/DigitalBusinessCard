using Application.Features.TelephoneNumbers.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Core.Shared.Services;
using Domain.Concrete.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TelephoneNumbers.Commands.Update
{
    public class UpdateUserTelephoneNumberCommand : IRequest<UpdatedUserTelephoneNumberDto>
    {
        public int Id { get; set; }
        public int UserTelephoneTypeId { get; set; }
        public int UserTelephoneCountryId { get; set; }
        public string TelephoneNumber { get; set; }
        public class UpdateUserTelephoneNumberCommandHandler : IRequestHandler<UpdateUserTelephoneNumberCommand, UpdatedUserTelephoneNumberDto>
        {
            private IUserTelephoneNumberRepository _userTelephoneNumberRepository;
            private ISharedIdentityService _sharedIdentityService;
            private IMapper _mapper;

            public UpdateUserTelephoneNumberCommandHandler(IUserTelephoneNumberRepository userTelephoneNumberRepository, ISharedIdentityService sharedIdentityService, IMapper mapper)
            {
                _userTelephoneNumberRepository = userTelephoneNumberRepository;
                _sharedIdentityService = sharedIdentityService;
                _mapper = mapper;
            }

            public async Task<UpdatedUserTelephoneNumberDto> Handle(UpdateUserTelephoneNumberCommand request, CancellationToken cancellationToken)
            {
                var model = _mapper.Map<UserTelephoneNumber>(request);
                model.UserId = _sharedIdentityService.GetUserId;
                await _userTelephoneNumberRepository.UpdateAsync(model);
                var result = _mapper.Map<UpdatedUserTelephoneNumberDto>(model);
                return result;
            }
        }
    }
}
