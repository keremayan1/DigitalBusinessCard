using Domain.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configurations
{
    public class UserTelephoneNumberConfiguration : IEntityTypeConfiguration<UserTelephoneNumber>
    {
        public void Configure(EntityTypeBuilder<UserTelephoneNumber> builder)
        {
            builder.ToTable("UserTelephoneNumbers").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.UserId).HasColumnName("UserId");
            builder.Property(x => x.UserTelephoneTypeId).HasColumnName("UserTelephoneTypeId");
            builder.Property(x => x.UserTelephoneCountryId).HasColumnName("UserTelephoneCountryId");
            builder.Property(x => x.TelephoneNumber).HasColumnName("TelephoneNumber");
            builder.HasOne(x => x.UserTelephoneType).WithMany();
            builder.HasOne(x => x.UserTelephoneCountry).WithOne();
        }
    }
}
