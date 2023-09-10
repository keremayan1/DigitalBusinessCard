using Application.Features.IbanAccounts.Commands.Add;
using Application.Features.IbanAccounts.Commands.Delete;
using Application.Features.IbanAccounts.Commands.Update;
using Application.Features.IbanAccounts.DTOs;
using Application.Features.IbanAccounts.Models;
using Application.Features.IbanAccounts.Queries.GetList;
using Core.Shared.BaseController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IbanAccountController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IbanAccountModel result = await Mediator.Send(new GetListIbanAccountQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateIbanAccountCommand createCompanyIbanAccountCommand)
        {
            CreatedIbanAccountDto result = await Mediator.Send(createCompanyIbanAccountCommand);
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateIbanAccountCommand updateCompanyIbanAccountCommand)
        {
            UpdatedIbanAccountDto result = await Mediator.Send(updateCompanyIbanAccountCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            DeletedIbanAccountDto result = await Mediator.Send(new DeleteIbanAccountCommand { Id = id });
            return Ok(result);
        }
    }
}
