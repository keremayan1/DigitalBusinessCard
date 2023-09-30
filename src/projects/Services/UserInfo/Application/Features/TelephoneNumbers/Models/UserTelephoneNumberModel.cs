using Application.Features.TelephoneNumbers.DTOs;
using Core.Persistance.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TelephoneNumbers.Models
{
    public class UserTelephoneNumberModel:BasePageableModel
    {
        public IList<GetByUserTelephoneNumberDto> Items { get; set; }
    }
}
