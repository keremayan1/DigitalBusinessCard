using Core.Persistance.Repositories;
using Core.Persistance.Repositories.EntityFramework;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete.Entities
{
    public class UserTelephoneNumber:Entity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int UserTelephoneTypeId { get; set; }
        public int UserTelephoneCountryId { get; set; }
        public string TelephoneNumber { get; set; }

        public virtual UserTelephoneType UserTelephoneType { get; set; }
        public virtual UserTelephoneCountry  UserTelephoneCountry { get; set; }
        public UserTelephoneNumber()
        {
            
        }

        public UserTelephoneNumber(int ıd, string userId, int telephoneTypeId, string telephoneNumber ):this()
        {
            Id = ıd;
            UserId = userId;
            UserTelephoneTypeId = telephoneTypeId;
            TelephoneNumber = telephoneNumber;
            
        }
    }
}
