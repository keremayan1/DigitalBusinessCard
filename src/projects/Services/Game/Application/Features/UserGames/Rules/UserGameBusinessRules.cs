using Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGames.Rules
{
    public class UserGameBusinessRules
    {
        private IUserGameRepository _userGameRepository;
        public UserGameBusinessRules(IUserGameRepository userGameRepository)
        {
            _userGameRepository = userGameRepository;
        }
        public async Task CheckIfUserGameIdWhenUpdated(int id)
        {
            var result = await _userGameRepository.GetAsync(x => x.Id == id);
            if (result == null)
            {
                throw new Exception("User Not Found!");
            }

        }
    }
}
