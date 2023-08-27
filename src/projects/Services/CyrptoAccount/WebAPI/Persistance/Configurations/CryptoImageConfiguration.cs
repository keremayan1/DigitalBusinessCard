using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities;

namespace WebAPI.Persistance.Configurations
{
    public class CryptoImageConfiguration : IEntityTypeConfiguration<CryptoImage>
    {
        public void Configure(EntityTypeBuilder<CryptoImage> builder)
        {
            builder.ToTable("CryptoImages").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.CryptoId).HasColumnName("CryptoId");
            builder.Property(x => x.ImagePath).HasColumnName("ImagePath");
            builder.Property(x => x.Date).HasColumnName("Date");

            builder.HasOne(x => x.Crypto);
        }
    }
}
