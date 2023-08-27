using Application.Services.Repositories;
using Core.Persistance.Repositories.EntityFramework;
using Domain.Entities.Concrete;
using Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Repositories
{
    public class SectorRepository : EfRepositoryBase<Sector, SQLDbContext>, ISectorRepository
    {
        public SectorRepository(SQLDbContext context) : base(context)
        {
        }
    }
}
