using Core.Shared.BaseController;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Features.UserCryptos.Commands.Add;
using WebAPI.Application.Features.UserCryptos.Commands.Delete;
using WebAPI.Application.Features.UserCryptos.Commands.Update;
using WebAPI.Application.Features.UserCryptos.DTOs;
using WebAPI.Application.Features.UserCryptos.Models;
using WebAPI.Application.Features.UserCryptos.Queries.GetList;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserCryptosController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            UserCryptoModel result = await Mediator.Send(new GetListUserCryptoQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm]CreateUserCryptoCommand createUserCryptoCommand)
        {
            CreatedUserCryptoDto result = await Mediator.Send(createUserCryptoCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            DeletedUserCryptoDto result = await Mediator.Send(new DeleteUserCryptoCommand { Id = id });
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateUserCryptoCommand updateUserCryptoCommand)
        {
            UpdatedUserCryptoDto result = await Mediator.Send(updateUserCryptoCommand);
            return Ok(result);

        }
    }
}
