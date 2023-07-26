using Application.Features.SocialMedias.DTOs;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Models
{
    public class SocialMediaModel:BasePageableModel
    {
        public IList<GetListSocialMediaDto> Items { get; set; }
    }
}
