using AuthServer.API.Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Hashing;

namespace AuthServer.API.Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task CheckPasswordOldWrong(string email, string oldPassword)
        {
            var user = await _userRepository.GetAsync(x => x.Email == email);
            if (user == null)
            {
                throw new AuthorizationException("User is not exist");
            }
            if (!HashingHelper.VerifyPasswordHash(oldPassword, user.PasswordHash, user.PasswordSalt))
            {
                throw new AuthorizationException("Sign in old password");
            }
            return;
        }
        public bool CheckIfOldPasswordAndNewPasswordAreExists(string oldPassword, string newPassword)
        {
            var result = oldPassword == newPassword;
            if (result)
            {
                throw new BusinessException("Old password and new password  doesn't exists");
            }
            return result;
        }
        public bool CheckPasswordSame(string password, string passwordVerify)
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
