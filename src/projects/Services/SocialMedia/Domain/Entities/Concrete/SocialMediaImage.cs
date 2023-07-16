using Core.Persistance.Repositories.EntityFramework;

namespace Domain.Entities.Concrete
{
    public class SocialMediaImage : Entity
    {
        public int Id { get; set; }
        public int SocialMediaId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
