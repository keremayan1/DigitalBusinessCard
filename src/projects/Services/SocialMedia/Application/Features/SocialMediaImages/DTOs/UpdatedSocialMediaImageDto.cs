namespace Application.Features.SocialMediaImages.DTOs
{
    public class UpdatedSocialMediaImageDto
    {
        public int Id { get; set; }
        public int SocialMediaId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
