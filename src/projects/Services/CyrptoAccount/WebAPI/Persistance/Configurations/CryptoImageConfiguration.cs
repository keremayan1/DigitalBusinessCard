using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities;

namespace WebAPI.Persistance.Configurations
{
    public class CryptoImageConfiguration : IEntityTypeConfiguration<CryptoImage>
    {
        public void Configure(EntityTypeBuilder<CryptoImage> builder)
        {
            builder.ToTable("crypto_images").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CryptoId).HasColumnName("crypto_id");
            builder.Property(x => x.ImagePath).HasColumnName("image_path");
            builder.Property(x => x.Date).HasColumnName("date");

            builder.HasOne(x => x.Crypto);
        }
    }
}
