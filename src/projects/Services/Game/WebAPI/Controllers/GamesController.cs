using Application.Features.Games.Commands.Add;
using Application.Features.Games.Commands.Delete;
using Application.Features.Games.Commands.Update;
using Application.Features.Games.DTOs;
using Application.Features.Games.Models;
using Application.Features.Games.Queries.GetList;
using Core.Shared.BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GamesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGameCommand createGameCommand)
        {
            CreatedGameDto result = await Mediator.Send(createGameCommand);
            return Created("", result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            DeletedGameDto result = await Mediator.Send(new DeleteGameCommand { Id=id});
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGameCommand updateGameCommand)
        {
            UpdatedGameDto result = await Mediator.Send(updateGameCommand);
            return Created("", result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GameModel result = await Mediator.Send(new GetListGameQuery());
            return Created("", result);
        }
    }
}
