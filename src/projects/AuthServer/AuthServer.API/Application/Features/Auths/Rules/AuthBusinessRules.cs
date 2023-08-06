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
        }
        public async Task CheckPasswordOldWrong(string email,string oldPassword)
        {
            var user = await _userRepository.GetAsync(x=>x.Email==email);
            if (user==null)
            {
                throw new AuthorizationException("User is not exist");
            }
            if (!HashingHelper.VerifyPasswordHash(oldPassword,user.PasswordHash,user.PasswordSalt))
            {
                throw new AuthorizationException("Sign in old password");
            }
            return;
        }
        public bool CheckIfOldPasswordAndNewPasswordAreExists(string oldPassword,string newPassword)
        {
            var result = oldPassword == newPassword;
            if (result)
            {
                throw new BusinessException("Old password and new password  doesn't exists");
            }
            return result;
        }
        public bool CheckPasswordSame(string password,string passwordVerify)
        {
            var result = password == passwordVerify;
            if (!result)
            {
                throw new AuthorizationException("This password and passwordVerify doesn't exist");
            }
            return result;
        }

    }
}
