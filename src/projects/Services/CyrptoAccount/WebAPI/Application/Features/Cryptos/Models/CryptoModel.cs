using Core.Persistance.Paging;
using WebAPI.Application.Features.Cryptos.DTOs;

namespace WebAPI.Application.Features.Cryptos.Models
{
    public class CryptoModel:BasePageableModel
    {
        public IList<GetListCryptoDto> Items { get; set; }
    }
}
