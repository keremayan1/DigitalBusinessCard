using Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GameImages.Rules
{
    public class GameImageBusinessRules
    {
        private IGameImageRepository _gameImageRepository;

        public GameImageBusinessRules(IGameImageRepository gameImageRepository)
        {
            _gameImageRepository = gameImageRepository;
        }
        public async Task<bool> CheckIfGameIdExists(int gameId)
        {
            var result = await _gameImageRepository.GetAsync(x => x.GameId == gameId);
            if (result != null)
            {
                throw new Exception("Bu Oyunun Resmi Sistemde Bulunmaktadır!");
            }
            return true;
        }
        public async Task<bool> CheckIfGameIdIsNull(int gameId)
        {
            var result = await _gameImageRepository.GetAsync(x => x.GameId == gameId);
            if (result == null)
            {
                throw new Exception("Bu Oyunun Kayıdı Sistemde Bulunmamaktadır!");
            }
            return true;
        }
    }
}
