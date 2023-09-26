using Application.Features.Biographies.Commands.Add;
using Application.Features.Biographies.Commands.Delete;
using Application.Features.Biographies.Commands.Update;
using Application.Features.Biographies.DTOs;
using Application.Features.Biographies.Models;
using Application.Features.Biographies.Queries.GetByUserId;
using Application.Features.Images.Commands.Add;
using Application.Features.Images.Commands.Delete;
using Application.Features.Images.Commands.Update;
using Application.Features.Images.DTOs;
using Core.Shared.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateUserImageCommand createUserImageCommand)
        {
            CreatedUserImageDto result = await Mediator.Send(createUserImageCommand);
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateUserImageCommand updateUserImageCommand)
        {
            UpdatedUserImageDto result = await Mediator.Send(updateUserImageCommand);
            return Created("", result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            DeletedUserImageDto result = await Mediator.Send(new DeleteUserImageCommand { Id = id });
            return Created("", result);
        }
        //[HttpGet]
        //public async Task<IActionResult> GetByUserId()
        //{
        //    ImageModel result = await Mediator.Send(new GetByImageUserIdQuery());
        //    return Ok(result);
        //}
    }
}
