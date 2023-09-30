using Application.Features.Biographies.Commands.Add;
using Application.Features.Biographies.Commands.Delete;
using Application.Features.Biographies.Commands.Update;
using Application.Features.Biographies.DTOs;
using Application.Features.Biographies.Models;
using Application.Features.Biographies.Queries.GetByUserId;
using Application.Features.TelephoneNumbers.Commands.Add;
using Application.Features.TelephoneNumbers.Commands.Delete;
using Application.Features.TelephoneNumbers.Commands.Update;
using Application.Features.TelephoneNumbers.DTOs;
using Application.Features.TelephoneNumbers.Models;
using Application.Features.TelephoneNumbers.Queries.GetByUserId;
using Core.Shared.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TelephoneNumbersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserTelephoneNumberCommand createUserTelephoneNumberCommand)
        {
            CreatedUserTelephoneNumberDto result = await Mediator.Send(createUserTelephoneNumberCommand);
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserTelephoneNumberCommand updateUserTelephoneNumberCommand)
        {
            UpdatedUserTelephoneNumberDto result = await Mediator.Send(updateUserTelephoneNumberCommand);
            return Created("", result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            DeletedUserTelephoneNumberDto result = await Mediator.Send(new DeleteUserTelephoneNumberCommand { Id = id });
            return Created("", result);
        }
        [HttpGet]
        public async Task<IActionResult> GetByUserId()
        {
            UserTelephoneNumberModel result = await Mediator.Send(new GetByTelephoneNumberUserIdQuery());
            return Ok(result);
        }
    }
}
