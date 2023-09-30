using Application.Services.Repositories;
using Domain.Concrete.Entities;

namespace Application.Services.TelephoneCountry
{
    public class TelephoneCountryManager : ITelephoneCountryService
    {
        private IUserTelephoneCountryRepository _userTelephoneCountryRepository;

        public TelephoneCountryManager(IUserTelephoneCountryRepository userTelephoneCountryRepository)
        {
            _userTelephoneCountryRepository = userTelephoneCountryRepository;
        }

        public async Task<UserTelephoneCountry> Add(UserTelephoneCountry userTelephoneCountry)
        {
            var result = await _userTelephoneCountryRepository.AddAsync(userTelephoneCountry);
            return result;
        }

        public async Task<UserTelephoneCountry> Delete(int id)
        {
            var getId = await _userTelephoneCountryRepository.GetAsync(x => x.Id == id);
            var result = await _userTelephoneCountryRepository.DeleteAsync(getId);
            return result;
        }

        public async Task<List<UserTelephoneCountry>> GetAll()
        {
            var result = await _userTelephoneCountryRepository.GetListWithoutInclude();
            return (List<UserTelephoneCountry>)result;
        }

        public async Task<UserTelephoneCountry> Update(UserTelephoneCountry userTelephoneCountry)
        {
            var result = await _userTelephoneCountryRepository.UpdateAsync(userTelephoneCountry);
            return result;
        }
    }
}
