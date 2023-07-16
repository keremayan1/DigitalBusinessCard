using Application.Features.UserGames.DTOs;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserGames.Models
{
    public class UserGameModel:BasePageableModel
    {
        public IList<GetByUserGameDto> Items { get; set; }
    }
}
