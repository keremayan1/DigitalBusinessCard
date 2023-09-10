using Application.Features.CompanyInfos.DTOs;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CompanyInfos.Models
{
    public class CompanyInfoModel:BasePageableModel
    {
        public IList<GetByCompanyInfoDto> Items { get; set; }
    }
}
