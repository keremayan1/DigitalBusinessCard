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

namespace Application.Features.TelephoneNumbers.Commands.Delete
{
    public class DeleteUserTelephoneNumberCommand : IRequest<DeletedUserTelephoneNumberDto>
    {
        public int Id { get; set; }
        public class DeleteUserTelephoneNumberCommandHandler : IRequestHandler<DeleteUserTelephoneNumberCommand, DeletedUserTelephoneNumberDto>
        {
            private IUserTelephoneNumberRepository _userTelephoneNumberRepository;
            private IMapper _mapper;

            public DeleteUserTelephoneNumberCommandHandler(IUserTelephoneNumberRepository userTelephoneNumberRepository, IMapper mapper)
            {
                _userTelephoneNumberRepository = userTelephoneNumberRepository;
                _mapper = mapper;
            }

            public async Task<DeletedUserTelephoneNumberDto> Handle(DeleteUserTelephoneNumberCommand request, CancellationToken cancellationToken)
            {
                var getId = await _userTelephoneNumberRepository.GetAsync(x => x.Id == request.Id);
                await _userTelephoneNumberRepository.DeleteAsync(getId);

                var result = _mapper.Map<DeletedUserTelephoneNumberDto>(getId);
                return result;
            }
        }
    }
}
