using Core.Shared.BaseController;
using IBANAccount.API.Application.Features.Iban.Commands.Add;
using IBANAccount.API.Application.Features.Iban.Commands.Delete;
using IBANAccount.API.Application.Features.Iban.Commands.Update;
using IBANAccount.API.Application.Features.Iban.DTOs;
using IBANAccount.API.Application.Features.Iban.Queries.GetList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IBANAccount.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IbansController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await Mediator.Send(new GetListIbanQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateIbanCommand createIbanCommand)
        {
            CreatedIbanDto result = await Mediator.Send(createIbanCommand);
            return Created("", result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            DeletedIbanDto result = await Mediator.Send(new DeleteIbanCommand { Id = id });
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateIbanCommand updateIbanCommand)
        {
            UpdatedIbanDto result = await Mediator.Send(updateIbanCommand);
            return Ok(result);
        }
    }
}
