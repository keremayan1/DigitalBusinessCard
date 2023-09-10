using Core.Persistance.Repositories.EntityFramework;

namespace Domain.Entities.Concrete
{
    public class IbanInfoImage : Entity
    {
        public int Id { get; set; }
        public int IbanInfoId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        public virtual IbanInfo? IbanInfo { get; set; }

        public IbanInfoImage(int ıd, int ıbanInfoId, string ımagePath, DateTime date):this()
        {
            Id = ıd;
            IbanInfoId = ıbanInfoId;
            ImagePath = ımagePath;
            Date = date;
        }

        public IbanInfoImage()
        {
                
        }
    }

}
