using Application.Features.IbanAccounts.DTOs;

namespace Application.Features.IbanAccounts.Models
{
    public class IbanAccountModel
    {
        public IList<GetByIbanAccountDto> Items { get; set; }
    }
}
