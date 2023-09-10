using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configurations
{
    public class CompanyInfoConfiguration : IEntityTypeConfiguration<CompanyInfo>
    {
        public void Configure(EntityTypeBuilder<CompanyInfo> builder)
        {
            builder.ToTable("CompanyInfos").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.UserId).HasColumnName("UserId");
            builder.Property(x => x.SectorId).HasColumnName("SectorId");
            builder.Property(x => x.CompanyName).HasColumnName("CompanyName");
            builder.Property(x => x.CompanyTitle).HasColumnName("CompanyTitle");
            builder.Property(x => x.CompanyWebSiteUrl).HasColumnName("CompanyWebsiteUrl"); 
            builder.Property(x => x.CompanyEmail).HasColumnName("CompanyEmail");
            builder.Property(x => x.CompanyTelephoneNumber).HasColumnName("CompanyTelephoneNumber");
            builder.Property(x => x.Info).HasColumnName("Info");
            builder.Property(x => x.TaxNumber).HasColumnName("TaxNumber");
            builder.Property(x => x.TaxInfo).HasColumnName("TaxInfo");
            builder.Property(x => x.CompanyLogoPath).HasColumnName("CompanyLogoPath");
            builder.HasOne(x => x.Sector);
            builder.HasOne(x => x.CompanyInfoImage).WithOne(x=>x.CompanyInfo).HasForeignKey<CompanyInfoImage>(x=>x.CompanyId);
            builder.HasMany(x => x.Addresses);

        }
    }
}
