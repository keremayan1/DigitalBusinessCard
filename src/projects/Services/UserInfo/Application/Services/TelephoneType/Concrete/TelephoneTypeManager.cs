using Application.Services.Repositories;
using Domain.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.TelephoneType.Concrete
{
    public class TelephoneTypeManager : ITelephoneTypeService
    {
        private IUserTelephoneTypeRepository _userTelephoneTypeRepository;

        public TelephoneTypeManager(IUserTelephoneTypeRepository userTelephoneTypeRepository)
        {
            _userTelephoneTypeRepository = userTelephoneTypeRepository;
        }

        public async Task<UserTelephoneType> Add(UserTelephoneType userTelephoneType)
        {
            var result = await _userTelephoneTypeRepository.AddAsync(userTelephoneType);
            return result;
        }

        public async Task<UserTelephoneType> Delete(int id)
        {
            var getId = await _userTelephoneTypeRepository.GetAsync(x => x.Id == id);
           var result =  await _userTelephoneTypeRepository.DeleteAsync(getId);
            return result;

        }

        public async Task<List<UserTelephoneType>>GetAll()
        {
            var result = await _userTelephoneTypeRepository.GetListWithoutInclude();
            return (List<UserTelephoneType>)result;
        }

        public async Task<UserTelephoneType> Update(UserTelephoneType userTelephoneType)
        {
            var result = await _userTelephoneTypeRepository.UpdateAsync(userTelephoneType);
            return result;
        }
    }
}
