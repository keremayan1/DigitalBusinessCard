using Application.Features.UserSocialMedias.Commands.Add;
using Application.Features.UserSocialMedias.Commands.Delete;
using Application.Features.UserSocialMedias.Commands.Update;
using Application.Features.UserSocialMedias.DTOs;
using Application.Features.UserSocialMedias.Models;
using Application.Features.UserSocialMedias.Queries.GetListByUserId;
using Core.Shared.BaseController;
using Core.Shared.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserSocialMediasController : BaseController
    {
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserSocialMediaCommand createUserSocialMediaCommand)
        {
            CreatedUserSocialMediaDto result = await Mediator.Send(createUserSocialMediaCommand);
            return Created("", result);
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id )
        {
            DeletedUserSocialMediaDto result = await Mediator.Send(new DeleteUserSocialMediaCommand { Id=id});
            return Ok(result);
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserSocialMediaCommand updateUserSocialMediaCommand)
        {
            UpdatedUserSocialMediaDto result = await Mediator.Send(updateUserSocialMediaCommand);
            return Ok(result);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            UserSocialMediaModel result = await Mediator.Send(new GetListUserSocialMediaByUserIdQuery());
            return Ok(result);
        }
    }
}