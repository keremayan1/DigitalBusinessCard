using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAPI.Domain.Entities;

namespace WebAPI.Persistance.Configurations
{
    public class UserCryptoConfiguration : IEntityTypeConfiguration<UserCyrpto>
    {
        public void Configure(EntityTypeBuilder<UserCyrpto> builder)
        {
            builder.ToTable("UserCrypto").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id)");
            builder.Property(x => x.CryptoId).HasColumnName("CryptoId");
            builder.Property(x => x.UserId).HasColumnName("UserId");
            builder.Property(x => x.CryptoUrl).HasColumnName("CryptoUrl");

            builder.HasOne(x => x.Crypto);
        }
    }
}
