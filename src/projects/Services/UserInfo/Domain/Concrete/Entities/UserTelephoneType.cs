using Core.Persistance.Repositories.EntityFramework;

namespace Domain.Concrete.Entities
{
    public class UserTelephoneType : Entity
    {
        public int Id { get; set; }
        public string TelephoneType { get; set; }

        public UserTelephoneType(int id, string telephoneType):this()
        {
            Id = id;
            TelephoneType = telephoneType;
        }
        public UserTelephoneType()
        {
            
        }

    }
}
