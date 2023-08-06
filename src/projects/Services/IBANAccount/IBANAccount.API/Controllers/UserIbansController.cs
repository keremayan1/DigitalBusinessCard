using Core.Shared.BaseController;
using IBANAccount.API.Application.Features.UserIbans.Commands.Add;
using IBANAccount.API.Application.Features.UserIbans.Commands.Delete;
using IBANAccount.API.Application.Features.UserIbans.Commands.Update;
using IBANAccount.API.Application.Features.UserIbans.DTOs;
using IBANAccount.API.Application.Features.UserIbans.Queries.GetList;
using Microsoft.AspNetCore.Mvc;

namespace IBANAccount.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserIbansController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetListUserIbanQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserIbanCommand createUserIbanCommand)
        {
            CreatedUserIbanDto result = await Mediator.Send(createUserIbanCommand);
            return Created("", result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            DeletedUserIbanDto result = await Mediator.Send(new DeleteUserIbanCommand { Id = id });
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserIbanCommand updateUserIbanCommand)
        {
            UpdatedUserIbanDto result = await Mediator.Send(updateUserIbanCommand);
            return Ok(result);
        }
    }
}
