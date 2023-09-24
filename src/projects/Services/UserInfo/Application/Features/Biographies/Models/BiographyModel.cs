using Application.Features.Biographies.DTOs;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Biographies.Models
{
    public class BiographyModel:BasePageableModel
    {
        public IList<GetListUserBiographyDto> Items { get; set; }
    }
}
