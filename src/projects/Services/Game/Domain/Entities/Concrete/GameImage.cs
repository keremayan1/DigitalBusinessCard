using Core.Persistance.Repositories.EntityFramework;

namespace Domain.Entities.Concrete
{
    public class GameImage : Entity
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

        public GameImage()
        {
            
        }
        public GameImage(int ıd, int gameId, string ımagePath, DateTime date):this()
        {
            Id = ıd;
            GameId = gameId;
            ImagePath = ımagePath;
            Date = date;
        }

        public virtual Game? Game { get; set; }
    }
}

