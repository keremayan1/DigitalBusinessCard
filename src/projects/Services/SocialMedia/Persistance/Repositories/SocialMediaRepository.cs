using Application.Services.Repositories;
using Core.Persistance.Repositories.EntityFramework;
using Domain.Entities.Concrete;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class SocialMediaRepository : EfRepositoryBase<SocialMedia, SQLContext>, ISocialMediaRepository
    {
        public SocialMediaRepository(SQLContext context) : base(context)
        {
        }
    }
}
