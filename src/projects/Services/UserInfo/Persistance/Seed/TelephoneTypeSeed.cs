using Domain.Concrete.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.Seed
{
    public class UserTelephoneTypeSeed : IEntityTypeConfiguration<UserTelephoneType>
    {
        public void Configure(EntityTypeBuilder<UserTelephoneType> builder)
        {
            builder.HasData(
                new UserTelephoneType { Id = 1,TelephoneType = "Kişisel Telefonu" },
                new UserTelephoneType { Id = 2, TelephoneType = "İş Telefonu" },
                new UserTelephoneType { Id = 3, TelephoneType = "Okul Telefonu" });
        }
    }
}
