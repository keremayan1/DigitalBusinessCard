using Core.Persistance.Paging;
using IBANAccount.API.Application.Features.Iban.DTOs;

namespace IBANAccount.API.Application.Features.Iban.Models
{
    public class IbanModel:BasePageableModel
    {
        public IList<GetIbanDto> Items { get; set; }
    }
}
