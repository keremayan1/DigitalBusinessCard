using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class IbanInfoImageConfiguration : IEntityTypeConfiguration<IbanInfoImage>
    {
        public void Configure(EntityTypeBuilder<IbanInfoImage> builder)
        {
            builder.ToTable("IbanInfoImages").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.IbanInfoId).HasColumnName("IbanInfoId");
            builder.Property(x => x.Date).HasColumnName("Date");
            builder.Property(x => x.ImagePath).HasColumnName("ImagePath");

            builder.HasOne(x => x.IbanInfo);


        }
    }
}
