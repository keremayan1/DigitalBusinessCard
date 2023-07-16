using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGames.DTOs
{
    public class CreatedUserGameDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int GameId { get; set; }
        public string GameUrl { get; set; }
    }
}
