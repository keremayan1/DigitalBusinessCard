using Application.Services.Repositories;
using Core.Persistance.Repositories.EntityFramework;
using Domain.Entities.Concrete;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class CompanyInfoRepository : EfRepositoryBase<CompanyInfo, SQLDbContext>, ICompanyInfoRepository
    {
        public CompanyInfoRepository(SQLDbContext context) : base(context)
        {
        }
    }
}
