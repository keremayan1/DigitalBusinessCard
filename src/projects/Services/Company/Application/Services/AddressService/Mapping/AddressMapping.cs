using Application.Services.AddressService.Dtos;
using AutoMapper;
using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AddressService.Mapping
{
    public class AddressMapping:Profile
    {
        public AddressMapping()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
