using Application.Features.CompanyInfos.Commands.Add;
using Application.Features.CompanyInfos.Commands.Delete;
using Application.Features.CompanyInfos.Commands.Update;
using Application.Features.CompanyInfos.DTOs;
using Application.Features.CompanyInfos.Models;
using Application.Features.CompanyInfos.Queries.GetList;
using Core.Shared.BaseController;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyInfoController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            CompanyInfoModel result = await Mediator.Send(new GetListCompanyInfoQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateCompanyInfoCommand createCompanyInfoCommand)
        {
            CreatedCompanyInfoDto result = await Mediator.Send(createCompanyInfoCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            DeletedCompanyInfoDto result = await Mediator.Send(new DeleteCompanyInfoCommand { Id=id});
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCompanyInfoCommand updateCompanyInfoCommand)
        {
            UpdatedCompanyInfoDto result = await Mediator.Send(updateCompanyInfoCommand);
            return Ok(result);
        }

    }
}
