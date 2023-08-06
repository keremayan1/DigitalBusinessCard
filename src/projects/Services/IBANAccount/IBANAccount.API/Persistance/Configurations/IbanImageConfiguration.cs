using IBANAccount.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBANAccount.API.Persistance.Configurations
{
    public class IbanImageConfiguration : IEntityTypeConfiguration<IbanImage>
    {
        public void Configure(EntityTypeBuilder<IbanImage> builder)
        {
            builder.ToTable("IbanImages").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.IbanId).HasColumnName("IbanId");
            builder.Property(x => x.ImagePath).HasColumnName("ImagePath");
            builder.Property(x => x.Date).HasColumnName("Date");
           
        }
    }
}
