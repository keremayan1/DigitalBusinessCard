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
    public class GameRepository : EfRepositoryBase<Game, SQLContext>,IGameRepository
    {
        public GameRepository(SQLContext context) : base(context)
        {
        }
    }
}
