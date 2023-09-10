using Core.Persistance.Repositories.EntityFramework;

namespace Domain.Entities.Concrete
{
    public class IbanInfo : Entity
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public int Length { get; set; }
        public string Code { get; set; }

        public virtual IbanInfoImage? IbanInfoImage { get; set; }
        public IbanInfo()
        {

        }

        public IbanInfo(int id, string country, int length, string code) : this()
        {
            Id = id;
            Country = country;
            Length = length;
            Code = code;
        }
    }

}
