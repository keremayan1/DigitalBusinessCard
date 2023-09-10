using Core.Persistance.Repositories;
using Domain.Entities.Concrete;

namespace Application.Services.Repositories
{
    public interface ICompanyInfoImageRepository : IRepository<CompanyInfoImage>, IAsyncRepository<CompanyInfoImage>
    {
    }
}
