using Application.Features.Images.DTOs;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Images.Models
{
    public class UserImageModel:BasePageableModel
    {
        public IList<GetByUserImageDto> Items { get; set; }
    }
}
