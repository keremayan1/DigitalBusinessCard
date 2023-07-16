using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Games.Rules
{
    public class GameBusinessRules
    {
        private IGameRepository _gameRepository;

        public GameBusinessRules(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public async Task GameNameCannotBeExistsWhenAdded(string gameName)
        {
            var result = await _gameRepository.GetAsync(x=>x.GameName.ToLower()==gameName.ToLower());
            if (result!=null)
            {
                throw new BusinessException("Name is exists in system!");
            }

        }
    }
}
