﻿namespace Application.Features.UserSocialMedias.DTOs
{
    public class UpdatedUserSocialMediaDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int SocialMediaId { get; set; }
        public string SocialMediaUrl { get; set; }
    }
}
