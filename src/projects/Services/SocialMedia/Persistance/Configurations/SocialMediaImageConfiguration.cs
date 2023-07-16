using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class SocialMediaImageConfiguration : IEntityTypeConfiguration<SocialMediaImage>
    {
        public void Configure(EntityTypeBuilder<SocialMediaImage> builder)
        {
            builder.ToTable("SocialMediaImages").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.SocialMediaId).HasColumnName("SocialMediaId");
            builder.Property(x => x.ImagePath).HasColumnName("ImagePath");
            builder.Property(x => x.Date).HasColumnName("Date");
        }
    }
}
