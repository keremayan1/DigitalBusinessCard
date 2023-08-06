using IBANAccount.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBANAccount.API.Persistance.Configurations
{
    public class IbanConfiguration : IEntityTypeConfiguration<Iban>
    {
        public void Configure(EntityTypeBuilder<Iban> builder)
        {
            builder.ToTable("Ibans").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Country).HasColumnName("Country");
            builder.Property(x => x.Length).HasColumnName("Length");
            builder.Property(x => x.Code).HasColumnName("Code");
            builder.HasOne(x => x.IbanImage);
        }
    }
}
