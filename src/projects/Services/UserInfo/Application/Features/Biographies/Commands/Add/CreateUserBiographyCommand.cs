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

namespace Application.Features.Biographies.Commands.Add
{
    public class CreateUserBiographyCommand:IRequest<CreatedUserBiographyDto>
    {
        public string BiographyDescription { get; set; }
        public class CreateUserBiographyCommandHandler : IRequestHandler<CreateUserBiographyCommand, CreatedUserBiographyDto>
        {
            private IUserBiographyRepository _userBiographyRepository;
            private ISharedIdentityService _sharedIdentityService;
            private IMapper _mapper;
            private BiographyBusinessRules _biographyBusinessRules;

            public CreateUserBiographyCommandHandler(IUserBiographyRepository userBiographyRepository, ISharedIdentityService sharedIdentityService, IMapper mapper, BiographyBusinessRules biographyBusinessRules)
            {
                _userBiographyRepository = userBiographyRepository;
                _sharedIdentityService = sharedIdentityService;
                _mapper = mapper;
                _biographyBusinessRules = biographyBusinessRules;
            }

            public async Task<CreatedUserBiographyDto> Handle(CreateUserBiographyCommand request, CancellationToken cancellationToken)
            {
                var model = _mapper.Map<UserBiography>(request);
                model.UserId = _sharedIdentityService.GetUserId;

                await _biographyBusinessRules.CheckIfBiographyExistsWhenAdded(model.UserId);
                _biographyBusinessRules.PropertyTrim(model);

                await _userBiographyRepository.AddAsync(model);

                var result = _mapper.Map<CreatedUserBiographyDto>(model);
                return result;
            }
        }
    }
}
