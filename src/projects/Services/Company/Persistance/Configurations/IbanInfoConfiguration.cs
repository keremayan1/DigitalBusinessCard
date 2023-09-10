using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class IbanInfoConfiguration : IEntityTypeConfiguration<IbanInfo>
    {
        public void Configure(EntityTypeBuilder<IbanInfo> builder)
        {
            builder.ToTable("IbanInfos").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Country).HasColumnName("Country");
            builder.Property(x => x.Length).HasColumnName("Length");
            builder.Property(x => x.Code).HasColumnName("Code");
           
            builder.HasOne(x => x.IbanInfoImage);
        

        }
    }
}
