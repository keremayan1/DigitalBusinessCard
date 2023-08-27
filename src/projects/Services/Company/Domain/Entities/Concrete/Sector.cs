using Core.Persistance.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Concrete
{
    public class Sector : Entity
    {
        public int Id { get; set; }
        public string SectorName { get; set; }

    }

}
