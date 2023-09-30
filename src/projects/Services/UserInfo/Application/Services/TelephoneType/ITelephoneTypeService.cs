using Domain.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TelephoneType
{
    public interface ITelephoneTypeService
    {
        Task<List<UserTelephoneType>> GetAll();
        Task<UserTelephoneType> Add(UserTelephoneType userTelephoneType);
        Task<UserTelephoneType> Delete(int id);
        Task<UserTelephoneType> Update(UserTelephoneType userTelephoneType);
    }
}
