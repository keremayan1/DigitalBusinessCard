using Core.Persistance.Paging;
using WebAPI.Application.Features.Cryptos.DTOs;
using WebAPI.Application.Features.UserCryptos.DTOs;

namespace WebAPI.Application.Features.UserCryptos.Models
{
    public class UserCryptoModel:BasePageableModel
    {
        public IList<GetListUserCryptoDto> Items { get; set; }
    }
}
