using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GameImages.DTOs
{
    public class CreatedGameImageDto
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
