using Core.Persistance.Repositories.EntityFramework;

namespace Domain.Concrete.Entities
{
    public class UserTelephoneCountry : Entity
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public string CountryDialCode { get; set; }
        public string CountryCode { get; set; }




    }
}
