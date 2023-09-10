using Application.Features.BankAccounts.Queries.GetList;
using Application.Features.IbanInfos.Commands.Add;
using Application.Features.IbanInfos.Commands.Delete;
using Application.Features.IbanInfos.Commands.Update;
using Application.Features.IbanInfos.DTOs;
using Application.Features.IbanInfos.Models;
using Core.Shared.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IbanInfosController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           IbanInfoModel result = await Mediator.Send(new GetListIbanInfoQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateIbanInfoCommand createIbanInfoCommand)
        {
            CreatedIbanInfoDto result = await Mediator.Send(createIbanInfoCommand);
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateIbanInfoCommand updateIbanInfoCommand)
        {
            UpdatedIbanInfoDto result = await Mediator.Send(updateIbanInfoCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            DeletedIbanInfoDto result = await Mediator.Send(new DeleteIbanInfoCommand { Id = id });
            return Ok(result);
        }
    }
}
