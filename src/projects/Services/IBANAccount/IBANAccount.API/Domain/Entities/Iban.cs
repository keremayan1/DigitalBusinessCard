using Core.Persistance.Repositories.EntityFramework;

namespace IBANAccount.API.Domain.Entities
{
    public class Iban:Entity
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public int Length { get; set; }
        public string Code { get; set; }

        public virtual IbanImage? IbanImage { get; set; }
    }
}
