using Application.Features.IbanInfos.DTOs;
using Core.Persistance.Paging;

namespace Application.Features.IbanInfos.Models
{
    public class IbanInfoModel : BasePageableModel
    {
        public IList<GetByIbanInfoDto> Items { get; set; }
    }
}
