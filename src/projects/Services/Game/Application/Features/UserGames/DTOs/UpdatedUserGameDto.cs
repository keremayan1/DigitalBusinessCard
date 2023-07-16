namespace Application.Features.UserGames.DTOs
{
    public class UpdatedUserGameDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int GameId { get; set; }
        public string GameUrl { get; set; }
    }
}
