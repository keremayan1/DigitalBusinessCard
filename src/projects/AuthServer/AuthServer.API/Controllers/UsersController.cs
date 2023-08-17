using AuthServer.API.Application.Features.Users.Commands.EditPassword;
using Core.Security.Dtos;
using Core.Shared.BaseController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.API.Controllers
{
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
    }
}
