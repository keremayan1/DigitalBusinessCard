using Core.Persistance.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Entities
{
    public class UserImage:Entity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

        public UserImage(int id, string userId, string imagePath, DateTime date):this()
        {
            Id = id;
            UserId = userId;
            ImagePath = imagePath;
            Date = date;
        }

        public UserImage()
        {
            
        }
    }
}
