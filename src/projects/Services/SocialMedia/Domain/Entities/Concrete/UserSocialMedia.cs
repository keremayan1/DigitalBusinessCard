using Core.Persistance.Repositories.EntityFramework;

namespace Domain.Entities.Concrete
{
    public class UserSocialMedia : Entity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int SocialMediaId { get; set; }
        public string SocialMediaUrl { get; set; }

        public virtual SocialMedia? SocialMedia { get; set; }

    }
}
