using Core.Persistance.Repositories.EntityFramework;

namespace WebAPI.Domain.Entities
{
    public class CryptoImage:Entity
    {
        public int Id { get; set; }
        public int   CryptoId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

        public virtual Crypto? Crypto { get; set; }

        public CryptoImage(int id, int cryptoId, string ımagePath, DateTime date):base()
        {
            Id = id;
            CryptoId = cryptoId;
            ImagePath = ımagePath;
            Date = date;
        }

        public CryptoImage()
        {
                
        }

    }
}
