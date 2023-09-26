using AuthServer.API.Application.Features.Users.Commands.EditEmail;
using AuthServer.API.Application.Features.Users.Commands.EditPassword;
using Core.Security.Dtos;
using Core.Shared.BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.API.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> EditPassword([FromBody] EditPasswordCommand editPasswordCommand)
        {
            UserForUpdatePasswordDto result = await Mediator.Send(editPasswordCommand);
            return Ok(result);

        }
        [HttpPost]
        public async Task<IActionResult> EditEmail([FromBody] EditEmailCommand editEmailCommand)
        {
            UserForUpdateEmailDto result = await Mediator.Send(editEmailCommand);
            return Ok(result);

        }
    }
}
