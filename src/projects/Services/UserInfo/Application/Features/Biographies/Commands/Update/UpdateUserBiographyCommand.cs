using Application.Features.Biographies.DTOs;
using Application.Features.Biographies.Rules;
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

namespace Application.Features.Biographies.Commands.Update
{
    public class UpdateUserBiographyCommand : IRequest<UpdatedUserBiographyDto>
    {
        public int Id { get; set; }
        public string BiographyDescription { get; set; }
        public class UpdateUserBiographyCommandHandler : IRequestHandler<UpdateUserBiographyCommand, UpdatedUserBiographyDto>
        {
            private IUserBiographyRepository _userBiographyRepository;
            private ISharedIdentityService _sharedIdentityService;
            private IMapper _mapper;
            private BiographyBusinessRules _biographyBusinessRules;

            public UpdateUserBiographyCommandHandler(IUserBiographyRepository userBiographyRepository, ISharedIdentityService sharedIdentityService, IMapper mapper, BiographyBusinessRules biographyBusinessRules)
            {
                _userBiographyRepository = userBiographyRepository;
                _sharedIdentityService = sharedIdentityService;
                _mapper = mapper;
                _biographyBusinessRules = biographyBusinessRules;
            }

            public async Task<UpdatedUserBiographyDto> Handle(UpdateUserBiographyCommand request, CancellationToken cancellationToken)
            {
                var model = _mapper.Map<UserBiography>(request);
                model.UserId = _sharedIdentityService.GetUserId;

            
                _biographyBusinessRules.PropertyTrim(model);

                await _userBiographyRepository.UpdateAsync(model);

                var result = _mapper.Map<UpdatedUserBiographyDto>(model);
                return result;
            }
        }
    }
}
