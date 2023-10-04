using Core.Persistance.Repositories.EntityFramework;

namespace Domain.Concrete.Entities
{
    public class UserBiography : Entity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string BiographyDescription { get; set; }
        public UserBiography()
        {

        }

        public UserBiography(int id, string userId, string biographyDescription) : this()
        {
            Id = id;
            UserId = userId;
            BiographyDescription = biographyDescription;
        }
    }
    
}
