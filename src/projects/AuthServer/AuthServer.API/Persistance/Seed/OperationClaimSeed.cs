using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServer.API.Persistance.Seed
{
    public class OperationClaimSeed : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.HasData(
                new OperationClaim { Id=1,Name="admin"},
                new OperationClaim { Id = 2, Name = "moderator" },
                new OperationClaim { Id = 3, Name = "user" });
        }
    }
}
