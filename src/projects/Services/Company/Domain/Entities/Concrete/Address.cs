using Core.Persistance.Repositories.EntityFramework;

namespace Domain.Entities.Concrete
{
    public class Address : Entity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string AddressName { get; set; }
        public string AddressDescription { get; set; }
    }

}
