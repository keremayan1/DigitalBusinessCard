using Core.Persistance.Repositories.EntityFramework;

namespace WebAPI.Domain.Entities
{
    public class Crypto : Entity
    {
        public int Id { get; set; }
        public string CryptoName { get; set; }

        public virtual CryptoImage? CryptoImage { get; set; }
        public virtual List<UserCyrpto?> UserCyrptos { get; set; }


    }
}
