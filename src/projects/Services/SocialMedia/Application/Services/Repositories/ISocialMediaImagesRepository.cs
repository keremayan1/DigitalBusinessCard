using Core.Persistance.Repositories;
using Domain.Entities.Concrete;

namespace Application.Services.Repositories
{
    public interface ISocialMediaImageRepository : IAsyncRepository<SocialMediaImage>, IRepository<SocialMediaImage>
    {
    }
}
