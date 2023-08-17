using Core.Persistance.Repositories.EntityFramework;

namespace Domain.Entities.Concrete
{
    public class SocialMedia:Entity
    {
        public int Id { get; set; }
        public string SocialMediaName { get; set; }

        public virtual SocialMediaImage? SocialMediaImage { get; set; }
        public virtual List<UserSocialMedia> UserSocialMedias { get; set; }

    }
}
