using Application.Features.SocialMediaImages.Commands.Add;
using Application.Features.SocialMediaImages.Commands.Delete;
using Application.Features.SocialMediaImages.Commands.Update;
using Application.Features.SocialMediaImages.DTOs;
using Application.Features.SocialMedias.Commands.Add;
using Application.Features.SocialMedias.DTOs;
using Core.Shared.BaseController;
using Core.Shared.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace WebAPI.Controllers
{
    //[Authorize]
    //[Route("api/[controller]/[action]")]
    //[ApiController]
    public class SocialMediaImagesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile formFile,int socialMediaId)
        {
            var result = await Mediator.Send(new CreateSocialMediaImageCommand { File = formFile,SocialMediaId =socialMediaId });
            return Created("",result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(IFormFile formFile, int socialMediaId)
        {
            var result = await Mediator.Send(new UpdateSocialMediaImageCommand { File = formFile, SocialMediaId = socialMediaId });
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int socialMediaId)
        {
            var result = await Mediator.Send(new DeleteSocialMediaImageCommand { SocialMediaId= socialMediaId });
            return Ok(result);
        }

    }
}