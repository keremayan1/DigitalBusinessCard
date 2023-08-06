using Core.Persistance.Repositories.EntityFramework;

namespace IBANAccount.API.Domain.Entities
{
    public class UserIban : Entity
    {
        public int Id { get; set; }
        public int IbanId { get; set; }
        public string UserId { get; set; }
        public string IbanUserName { get; set; }
        public string IbanNumber { get; set; }

        public virtual Iban? Iban { get; set; }
    }
}
