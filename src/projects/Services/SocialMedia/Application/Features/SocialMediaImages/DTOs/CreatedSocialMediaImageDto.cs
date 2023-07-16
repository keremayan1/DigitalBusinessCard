using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMediaImages.DTOs
{
    public class CreatedSocialMediaImageDto
    {
        public int SocialMediaId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
