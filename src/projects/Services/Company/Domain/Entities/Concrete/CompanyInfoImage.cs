using Core.Persistance.Repositories.EntityFramework;

namespace Domain.Entities.Concrete
{
    public class CompanyInfoImage : Entity
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

        public virtual CompanyInfo? CompanyInfo { get; set; }
        public CompanyInfoImage()
        {
            
        }

        public CompanyInfoImage(int id, int companyId, string ımagePath, DateTime date):this()
        {
            Id = id;
            CompanyId = companyId;
            ImagePath = ımagePath;
            Date = date;
        }
    }

}
