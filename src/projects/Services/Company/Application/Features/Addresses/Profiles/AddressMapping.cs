using Application.Features.Addresses.Commands.Add;
using Application.Features.Addresses.Commands.Delete;
using Application.Features.Addresses.Commands.Update;
using Application.Features.Addresses.DTOs;
using Application.Features.Addresses.Models;
using AutoMapper;
using Core.Persistance.Paging;
using Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Profiles
{
    public class AddressMapping:Profile
    {
        public AddressMapping()
        {
            CreateMap<Address, CreatedAddressDto>().ReverseMap();
            CreateMap<Address, CreateAddressCommand>().ReverseMap();

            CreateMap<Address, DeletedAddressDto>().ReverseMap();
            CreateMap<Address, DeleteAddressCommand>().ReverseMap();

            CreateMap<Address, UpdatedAddressDto>().ReverseMap();
            CreateMap<Address, UpdateAddressCommand>().ReverseMap();

            CreateMap<IPaginate<Address>, AddressModel>().ReverseMap();
            CreateMap<Address, GetByAddressDto>().ReverseMap();
        }
    }
}
