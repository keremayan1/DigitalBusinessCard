using Core.Persistance.Repositories.EntityFramework;

namespace Domain.Entities.Concrete
{
    public class Address : Entity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string AddressName { get; set; }
        public string AddressDescription { get; set; }
        public virtual CompanyInfo? Company { get; set; }
        public Address()
        {
                
        }

        public Address(int id, string addressName, string addressDescription):this()
        {
            Id = id;
            AddressName = addressName;
            AddressDescription = addressDescription;
        }
    }


}
