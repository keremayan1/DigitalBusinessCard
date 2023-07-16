using Core.Persistance.Repositories.EntityFramework;

namespace Domain.Entities.Concrete
{
    public class UserGame : Entity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int GameId { get; set; }
        public string GameUrl { get; set; }

        public virtual Game? Game { get; set; }
    }

}
