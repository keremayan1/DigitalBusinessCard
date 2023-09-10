using Core.Persistance.Repositories.EntityFramework;

namespace Domain.Entities.Concrete
{
    public class IbanAccount : Entity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int IbanInfoId { get; set; }
        public string IbanUserName { get; set; }
        public string IbanNumber { get; set; }

        public virtual IbanInfo? IbanInfo { get; set; }

        public IbanAccount()
        {
                
        }
        public IbanAccount(int id, int ibanInfoId, string ıbanUserName, string ıbanNumber):this()
        {
            Id = id;
            IbanInfoId = ibanInfoId;
            IbanUserName = ıbanUserName;
            IbanNumber = ıbanNumber;
        }
    }

}
