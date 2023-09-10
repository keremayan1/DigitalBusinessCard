using Application.Services.Repositories;
using Core.Persistance.Repositories.EntityFramework;
using Domain.Entities.Concrete;
using Persistance.Contexts;

namespace Persistance.Repositories
{
    public class CompanyInfoImageRepository : EfRepositoryBase<CompanyInfoImage, SQLDbContext>, ICompanyInfoImageRepository
    {
        public CompanyInfoImageRepository(SQLDbContext context) : base(context)
        {
        }
    }
}
