namespace Application.Features.UserGames.DTOs
{
    public class GetByUserGameDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string GameName { get; set; }
        public string GameUrl { get; set; }
    }
}
