using Core.CrossCuttingConcerns.Exceptions;
using WebAPI.Application.Services.Repositories;
using WebAPI.Domain.Entities;

namespace WebAPI.Application.Features.UserCryptos.Rules
{
    public class UserCryptoBusinessRules
    {
        private readonly IUserCryptoRepository _userCryptoRepository;

        public UserCryptoBusinessRules(IUserCryptoRepository userCryptoRepository)
        {
            _userCryptoRepository = userCryptoRepository;
        }
        public async Task CheckIfUserCryptoIsExistsWhenSavedOrUpdated(string cyrptoUrl)
        {
            var result = await _userCryptoRepository.GetAsync(x => x.CryptoUrl.ToLower() == cyrptoUrl.ToLower());
            if (result!=null)
            {
                throw new BusinessException("This CryptoUrl is exist in the system!");
            }
        }
    }
}
