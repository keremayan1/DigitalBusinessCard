using Application.Features.SocialMedias.Commands.Add;
using Application.Features.SocialMedias.Commands.Delete;
using Application.Features.SocialMedias.Commands.Update;
using Application.Features.SocialMedias.DTOs;
using Application.Features.SocialMedias.Queries.GetList;
using Core.Shared.BaseController;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SocialMediasController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSocialMediaCommand createSocialMediaCommand)
        {
            CreatedSocialMediaDto result = await Mediator.Send(createSocialMediaCommand);
            return Created("", result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteSocialMediaCommand deleteSocialMediaCommand)
        {
            DeletedSocialMediaDto result = await Mediator.Send(deleteSocialMediaCommand);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSocialMediaCommand updateSocialMediaCommand)
        {
            UpdatedSocialMediaDto result = await Mediator.Send(updateSocialMediaCommand);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var  result = await Mediator.Send(new GetListSocialMediaQuery());
            return Ok(result);
        }
    }
}