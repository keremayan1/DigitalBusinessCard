using Core.Security.Entities;

namespace Core.Security.Dtos
{
    public class UserForUpdatePasswordDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
