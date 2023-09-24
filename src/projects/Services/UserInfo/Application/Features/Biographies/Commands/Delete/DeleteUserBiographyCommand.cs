using Application.Features.Biographies.DTOs;
using Application.Services.Repositories;
using AutoMapper;
using Core.Shared.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Biographies.Commands.Delete
{
    public class DeleteUserBiographyCommand:IRequest<DeletedUserBiographyDto>
    {
        public int Id { get; set; }
        public class DeleteUserBiographyCommandHandler : IRequestHandler<DeleteUserBiographyCommand, DeletedUserBiographyDto>
        {
            private IUserBiographyRepository _userBiographyRepository;
            private ISharedIdentityService _sharedIdentityService;
            private IMapper _mapper;
           

            public DeleteUserBiographyCommandHandler(IUserBiographyRepository userBiographyRepository, ISharedIdentityService sharedIdentityService, IMapper mapper)
            {
                _userBiographyRepository = userBiographyRepository;
                _sharedIdentityService = sharedIdentityService;
                _mapper = mapper;
                
            }

            public async Task<DeletedUserBiographyDto> Handle(DeleteUserBiographyCommand request, CancellationToken cancellationToken)
            {
                var getId = await _userBiographyRepository.GetAsync(x => x.Id == request.Id);

                await _userBiographyRepository.DeleteAsync(getId);

                var result = _mapper.Map<DeletedUserBiographyDto>(getId);
                return result;
            }
        }
    }
}
