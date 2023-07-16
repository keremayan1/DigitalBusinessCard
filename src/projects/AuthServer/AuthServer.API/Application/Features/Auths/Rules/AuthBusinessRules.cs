using AuthServer.API.Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;

namespace AuthServer.API.Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task EmailShouldNotBeDuplicatedWhenRegistered(string email)
        {
            var user = await _userRepository.GetAsync(x => x.Email == email);
            if (user!=null)
            {
                throw new AuthorizationException("Email already exists");
            }
        }
        public async Task EmailCanNotBeExistWhenLogined(string email)
        {
            var getUser = await _userRepository.GetAsync(x => x.Email == email);
            if (getUser == null)
              throw new BusinessException("This email doesn't have in system!");

           
        }
        public async Task PasswordVerify(User user, UserForLoginDto userForLoginDto)
        {
            var isVerified = HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt);
            if (!isVerified)
                throw new AuthorizationException("Wrong Email or Password!");
           await Task.FromResult(isVerified);
        }

    }
}
