﻿using Core.Persistance.Repositories;
using Core.Persistance.Repositories.EntityFramework;

namespace Domain.Entities.Concrete
{
    public  class Game : Entity
    {
        public int Id { get; set; }
        public string GameName { get; set; }
    }

}