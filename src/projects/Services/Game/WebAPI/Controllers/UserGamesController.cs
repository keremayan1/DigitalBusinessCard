using Application.Features.UserGames.Commands.Add;
using Application.Features.UserGames.Commands.Delete;
using Application.Features.UserGames.Commands.Update;
using Application.Features.UserGames.DTOs;
using Application.Features.UserGames.Models;
using Application.Features.UserGames.Queries.GetListByUserId;
using Core.Shared.BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserGamesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserGameCommand createUserGameCommand)
        {
            CreatedUserGameDto result = await Mediator.Send(createUserGameCommand);
            return Created("", result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteUserGameCommand deleteUserGameCommand)
        {
            DeletedUserGameDto result = await Mediator.Send(deleteUserGameCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserGameCommand updateUserGameCommand)
        {
            UpdatedUserGameDto result = await Mediator.Send(updateUserGameCommand);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            UserGameModel result = await Mediator.Send(new GetListByUserIdQuery());
            return Ok(result);
        }
    }
}
