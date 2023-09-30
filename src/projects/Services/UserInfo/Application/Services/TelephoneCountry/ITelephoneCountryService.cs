using Domain.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TelephoneCountry
{
    public interface ITelephoneCountryService
    {
        Task<List<UserTelephoneCountry>> GetAll();
        Task<UserTelephoneCountry> Add(UserTelephoneCountry userTelephoneCountry);
        Task<UserTelephoneCountry> Delete(int id);
        Task<UserTelephoneCountry> Update(UserTelephoneCountry userTelephoneCountry);
    }
}
