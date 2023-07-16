using Core.Persistance.Repositories;
using Domain.Entities.Concrete;

namespace Application.Services.Repositories
{
    public interface ISocialMediaRepository : IAsyncRepository<SocialMedia>,IRepository<SocialMedia>
    {
    }
}
