using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Biographies.Rules
{
    public class BiographyBusinessRules
    {
        private IUserBiographyRepository _userBiographyRepository;

        public BiographyBusinessRules(IUserBiographyRepository userBiographyRepository)
        {
            _userBiographyRepository = userBiographyRepository;
        }
        public async Task CheckIfBiographyExistsWhenAdded(string userId)
        {
            var result = await _userBiographyRepository.GetAsync(x => x.UserId == userId);
            if (result != null)
            {
                throw new BusinessException($"{userId} Kullanıcıya ait bir biografi vardır!");
            }
        }
        public void PropertyTrim(UserBiography userBiography)
        {
            userBiography.BiographyDescription = userBiography.BiographyDescription.Trim();
        }
    }
}
