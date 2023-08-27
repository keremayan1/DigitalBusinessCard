using Application.Features.Addresses.Commands.Add;
using Application.Features.Addresses.Commands.Delete;
using Application.Features.Addresses.Commands.Update;
using Application.Features.Addresses.DTOs;
using Application.Features.Addresses.Models;
using Application.Features.Addresses.Queries.GetList;
using Core.Shared.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AddressesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            AddressModel result = await Mediator.Send(new GetListAddressQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAddressCommand createAddressCommand)
        {
            CreatedAddressDto result = await Mediator.Send(createAddressCommand);
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAddressCommand updateAddressCommand)
        {
            UpdatedAddressDto result = await Mediator.Send(updateAddressCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            DeletedAddressDto result = await Mediator.Send(new DeleteAddressCommand { Id = id });
            return Ok(result);
        }
    }
}
