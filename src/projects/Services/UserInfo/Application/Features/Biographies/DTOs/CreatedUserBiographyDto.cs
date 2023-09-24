using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Biographies.DTOs
{
    public class CreatedUserBiographyDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string BiographyDescription { get; set; }
    }
}
