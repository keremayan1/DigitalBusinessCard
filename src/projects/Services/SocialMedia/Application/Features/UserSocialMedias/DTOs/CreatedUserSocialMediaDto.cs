using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedias.DTOs
{
    public class CreatedUserSocialMediaDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int SocialMediaId { get; set; }
        public string SocialMediaUrl { get; set; }
    }
}
