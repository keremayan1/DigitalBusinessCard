using Core.Persistance.Repositories;
using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public interface ISectorRepository:IRepository<Sector>,IAsyncRepository<Sector>
    {
    }
}
