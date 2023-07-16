using Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedias.Rules
{
    public class UserSocialMediaBusinessRules
    {
        private IUserSocialMediaRepository _userSocialMediaRepository;

        public UserSocialMediaBusinessRules(IUserSocialMediaRepository userSocialMediaRepository)
        {
            _userSocialMediaRepository = userSocialMediaRepository;
        }
        public async Task CheckIfUserSocialMediaIdWhenUpdated(int id)
        {
            var result = await _userSocialMediaRepository.GetAsync(x => x.Id == id);
            if (result==null)
            {
                throw new Exception("User Not Found!");
            }

        }
    }
}
