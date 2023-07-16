using Application.Features.UserSocialMedias.DTOs;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMedias.Models
{
    public class UserSocialMediaModel:BasePageableModel
    {
        public IList<GetByUserSocialMediaDto> Items { get; set; }
    }
}
