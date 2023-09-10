using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Addresses").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");

            builder.Property(x => x.CompanyId).HasColumnName("CompanyId");
            builder.Property(x => x.AddressName).HasColumnName("AddressName");
            builder.Property(x => x.AddressDescription).HasColumnName("AddressDescription");
           
            builder.HasOne(x => x.Company);

        }
    }
}
