using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities;

namespace WebAPI.Persistance.Configurations
{
    public class UserCryptoConfiguration : IEntityTypeConfiguration<UserCyrpto>
    {
        public void Configure(EntityTypeBuilder<UserCyrpto> builder)
        {
            builder.ToTable("user_crypto").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.CryptoId).HasColumnName("crypto_id");
            builder.Property(x => x.UserId).HasColumnName("user_id");
            builder.Property(x => x.CryptoUrl).HasColumnName("crypto_url");

            builder.HasOne(x => x.Crypto);
        }
    }
}
