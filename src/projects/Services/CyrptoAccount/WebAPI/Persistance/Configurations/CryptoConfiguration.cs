using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities;

namespace WebAPI.Persistance.Configurations
{
    public class CryptoConfiguration : IEntityTypeConfiguration<Crypto>
    {
        public void Configure(EntityTypeBuilder<Crypto> builder)
        {
            builder.ToTable("cryptos").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CryptoName).HasColumnName("crypto_name");
            builder.HasOne(x => x.CryptoImage);
            builder.HasMany(x => x.UserCyrptos);
        }
    }
}
