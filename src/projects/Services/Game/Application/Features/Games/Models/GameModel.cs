using Application.Features.Games.DTOs;
using Application.Features.UserGames.DTOs;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Games.Models
{
    public class GameModel:BasePageableModel
    {
        public IList<GetListGameDto> Items { get; set; }
    }
}
