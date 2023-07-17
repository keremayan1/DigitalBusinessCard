using Application.Features.GameImages.Commands.Add;
using Application.Features.GameImages.Commands.Delete;
using Application.Features.GameImages.Commands.Update;
using Application.Features.Games.Commands.Delete;
using Core.Shared.BaseController;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameImagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile formFile, int gameId)
        {
            var result = await Mediator.Send(new CreateGameImageCommand { Photo = formFile, GameId = gameId });
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(IFormFile formFile, int gameId)
        {
            var result = await Mediator.Send(new UpdateGameImageCommand { Photo = formFile, GameId = gameId });
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int gameId)
        {
            var result = await Mediator.Send(new DeleteGameImageCommand { GameId = gameId });
            return Ok(result);
        }
    }
}
