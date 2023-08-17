using Core.Shared.BaseController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Features.Cryptos.Commands.Add;
using WebAPI.Application.Features.Cryptos.Commands.Delete;
using WebAPI.Application.Features.Cryptos.Commands.Update;
using WebAPI.Application.Features.Cryptos.DTOs;
using WebAPI.Application.Features.Cryptos.Models;
using WebAPI.Application.Features.Cryptos.Queries.GetList;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CryptosController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            CryptoModel result = await Mediator.Send(new GetListCryptoQuery());
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateCryptoCommand createCryptoCommand)
        {
            CreatedCryptoDto result = await Mediator.Send(createCryptoCommand);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            DeletedCryptoDto result = await Mediator.Send(new DeleteCryptoCommand { Id = id });
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateCryptoCommand updateCryptoCommand)
        {
            UpdatedCryptoDto result = await Mediator.Send(updateCryptoCommand);
            return Ok(result);

        }
    }
}
