using Application.Services.AddressService.Dtos;
using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AddressService
{
    public interface IAddressService
    {
        Task<AddressDto> Add(Address address);
        Task<AddressDto> Update(Address address);
        Task<AddressDto> Delete(int id);
    }
}
