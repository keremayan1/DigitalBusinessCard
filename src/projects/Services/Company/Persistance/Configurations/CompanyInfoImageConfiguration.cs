using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class CompanyInfoImageConfiguration : IEntityTypeConfiguration<CompanyInfoImage>
    {
        public void Configure(EntityTypeBuilder<CompanyInfoImage> builder)
        {
            builder.ToTable("CompanyInfoImages").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.CompanyId).HasColumnName("CompanyId");
            builder.Property(x => x.ImagePath).HasColumnName("ImagePath");
            builder.Property(x => x.Date).HasColumnName("Date");

          

        }
    }
}
