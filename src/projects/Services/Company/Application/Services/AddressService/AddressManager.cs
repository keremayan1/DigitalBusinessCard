using Application.Services.AddressService.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities.Concrete;

namespace Application.Services.AddressService
{
    public class AddressManager : IAddressService
    {
        private IAddressRepository _addressRepository;
        private IMapper _mapper;


        public AddressManager(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<AddressDto> Add(Address address)
        {
           
            await _addressRepository.AddAsync(address);
            var result = _mapper.Map<AddressDto>(address);
            return result;
        }

        public async Task<AddressDto> Delete(int companyId)
        {
            var getId = await _addressRepository.GetAsync(x => x.CompanyId == companyId);
            await _addressRepository.DeleteAsync(getId);
            var result = _mapper.Map<AddressDto>(getId);
            return result;
        }

        public async Task<AddressDto> Update(Address address)
        {
            var getId = await _addressRepository.GetAsync(x => x.CompanyId == address.CompanyId);

          
            getId.CompanyId = address.CompanyId;
            getId.AddressName = address.AddressName;
            getId.AddressDescription = address.AddressDescription;
            
            await _addressRepository.UpdateAsync(getId);
           
            
            var result = _mapper.Map<AddressDto>(address);
            return result;
        }
    }
}
