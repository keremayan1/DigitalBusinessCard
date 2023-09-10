using Core.Persistance.Repositories;
using Domain.Entities.Concrete;

namespace Application.Services.Repositories
{
    public interface ICompanyInfoRepository : IRepository<CompanyInfo>, IAsyncRepository<CompanyInfo>
    {
    }
}
