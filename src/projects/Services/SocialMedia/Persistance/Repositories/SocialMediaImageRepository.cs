using Application.Services.Repositories;
using Core.Persistance.Repositories.EntityFramework;
using Domain.Entities.Concrete;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class SocialMediaImageRepository : EfRepositoryBase<SocialMediaImage, SQLContext>, ISocialMediaImageRepository
    {
        public SocialMediaImageRepository(SQLContext context) : base(context)
        {
        }
    }
}
