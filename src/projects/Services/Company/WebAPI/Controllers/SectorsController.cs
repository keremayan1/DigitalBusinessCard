using Application.Features.Sectors.Commands.Add;
using Application.Features.Sectors.Commands.Delete;
using Application.Features.Sectors.Commands.Update;
using Application.Features.Sectors.DTOs;
using Application.Features.Sectors.Models;
using Application.Features.Sectors.Queries.GetList;
using Core.Shared.BaseController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SectorsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            SectorModel result = await Mediator.Send(new GetListSectorQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateSectorCommand createSectorCommand)
        {
            CreatedSectorDto result = await Mediator.Send(createSectorCommand);
            return Created("",result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSectorCommand updateSectorCommand)
        {
            UpdatedSectorDto result = await Mediator.Send(updateSectorCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            DeletedSectorDto result = await Mediator.Send(new DeleteSectorCommand { Id=id});
            return Ok(result);
        }
    }
}
