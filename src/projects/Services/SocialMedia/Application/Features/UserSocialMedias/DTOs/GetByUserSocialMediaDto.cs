namespace Application.Features.UserSocialMedias.DTOs
{
    public class GetByUserSocialMediaDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaUrl { get; set; }
    }
}
