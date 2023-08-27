using Application.Features.Sectors.DTOs;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Sectors.Models
{
    public class SectorModel:BasePageableModel
    {
        public IList<GetBySectorDto> Items { get; set; }
    }
}
