using Core.Persistance.Repositories.EntityFramework;

namespace Domain.Entities.Concrete
{
    public class GameImage : Entity
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}

