using Domain.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Configurations
{
    public class GameImageConfiguration : IEntityTypeConfiguration<GameImage>
    {
        public void Configure(EntityTypeBuilder<GameImage> builder)
        {
            builder.ToTable("GameImages").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.GameId).HasColumnName("GameId");
            builder.Property(x => x.ImagePath).HasColumnName("ImagePath");
            builder.Property(x => x.Date).HasColumnName("Date");
          
        }
    }
}

