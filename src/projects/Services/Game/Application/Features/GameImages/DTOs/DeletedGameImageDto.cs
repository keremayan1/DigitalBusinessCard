namespace Application.Features.GameImages.DTOs
{
    public class DeletedGameImageDto
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
