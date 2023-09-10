using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class IbanAccountConfiguration : IEntityTypeConfiguration<IbanAccount>
    {
        public void Configure(EntityTypeBuilder<IbanAccount> builder)
        {
            builder.ToTable("IbanAccounts").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.UserId).HasColumnName("UserId");
            builder.Property(x => x.IbanInfoId).HasColumnName("IbanInfoId");
            builder.Property(x => x.IbanUserName).HasColumnName("IbanUserName");
            builder.Property(x => x.IbanNumber).HasColumnName("IbanNumber");
            builder.HasOne(x => x.IbanInfo);
        }
    }
}
