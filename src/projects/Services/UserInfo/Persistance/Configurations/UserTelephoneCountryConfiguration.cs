using Domain.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class UserTelephoneCountryConfiguration : IEntityTypeConfiguration<UserTelephoneCountry>
    {
        public void Configure(EntityTypeBuilder<UserTelephoneCountry> builder)
        {
            builder.ToTable("UserTelephoneCountries").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.CountryName).HasColumnName("CountryName");
            builder.Property(x => x.CountryDialCode).HasColumnName("CountryDialCode");
            builder.Property(x => x.CountryCode).HasColumnName("CountryCode");
            
        }
    }
}
