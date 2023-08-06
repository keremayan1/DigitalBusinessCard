using Core.Persistance.Paging;
using IBANAccount.API.Application.Features.UserIbans.DTOs;

namespace IBANAccount.API.Application.Features.UserIbans.Models
{
    public class UserIbanModel:BasePageableModel
    {
        public IList<GetUserIbanDto> Items { get; set; }
    }
}
