using Core.Persistance.Repositories.EntityFramework;

namespace IBANAccount.API.Domain.Entities
{
    public class IbanImage : Entity
    {
        public int Id { get; set; }
        public int IbanId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
