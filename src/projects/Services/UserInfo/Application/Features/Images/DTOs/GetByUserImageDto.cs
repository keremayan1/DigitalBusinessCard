namespace Application.Features.Images.DTOs
{
    public class GetByUserImageDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

    }
}
