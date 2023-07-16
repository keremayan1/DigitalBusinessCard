using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class UserSocialMediaConfiguration : IEntityTypeConfiguration<UserSocialMedia>
    {
        public void Configure(EntityTypeBuilder<UserSocialMedia> builder)
        {
            builder.ToTable("UserSocialMedias").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.SocialMediaId).HasColumnName("SocialMediaId");
            builder.Property(x => x.SocialMediaUrl).HasColumnName("SocialMediaUrl");
            builder.HasOne(x => x.SocialMedia);
        }
    }
}
