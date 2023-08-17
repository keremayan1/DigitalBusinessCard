using Core.Persistance.Repositories.EntityFramework;

namespace WebAPI.Domain.Entities
{
    public class UserCyrpto : Entity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CryptoId { get; set; }
        public string CryptoUrl { get; set; }
        public virtual Crypto? Crypto { get; set; }
    }
}
