using Application.Features.Addresses.DTOs;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Models
{
    public class AddressModel:BasePageableModel
    {
        public IList<GetByAddressDto> Items { get; set; }

    }
}
