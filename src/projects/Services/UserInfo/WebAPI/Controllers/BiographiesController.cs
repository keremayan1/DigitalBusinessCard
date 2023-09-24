using Application.Features.Biographies.Commands.Add;
using Application.Features.Biographies.Commands.Delete;
using Application.Features.Biographies.Commands.Update;
using Application.Features.Biographies.DTOs;
using Application.Features.Biographies.Models;
using Application.Features.Biographies.Queries.GetByUserId;
using Core.Shared.BaseController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BiographiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserBiographyCommand createUserBiographyCommand)
        {
            CreatedUserBiographyDto result = await Mediator.Send(createUserBiographyCommand);
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserBiographyCommand updateUserBiographyCommand)
        {
            UpdatedUserBiographyDto result = await Mediator.Send(updateUserBiographyCommand);
            return Created("", result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id )
        {
            DeletedUserBiographyDto result = await Mediator.Send(new DeleteUserBiographyCommand { Id=id});
            return Created("", result);
        }
        [HttpGet]
        public async Task<IActionResult> GetByUserId()
        {
            BiographyModel result = await Mediator.Send(new GetByBiographyUserIdQuery());
            return Ok(result);
        }
    }
}
