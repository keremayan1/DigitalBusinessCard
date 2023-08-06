using IBANAccount.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBANAccount.API.Persistance.Configurations
{
    public class UserIbanConfiguration : IEntityTypeConfiguration<UserIban>
    {
        public void Configure(EntityTypeBuilder<UserIban> builder)
        {
            builder.ToTable("UserIbans").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.IbanId).HasColumnName("IbanId");
            builder.Property(x => x.UserId).HasColumnName("UserId");
            builder.Property(x => x.IbanNumber).HasColumnName("IbanNumber");
            builder.HasOne(x => x.Iban);
        }
    }
}
