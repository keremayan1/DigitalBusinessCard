using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AddressService.Dtos
{
    public class AddressDto
    {
        public int CompanyId { get; set; }
        public string AddressName { get; set; }
        public string AddressDescription { get; set; }
    }
}
