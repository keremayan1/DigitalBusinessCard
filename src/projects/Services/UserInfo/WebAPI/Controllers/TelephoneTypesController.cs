using Application.Services.TelephoneType;
using Core.Shared.BaseController;
using Domain.Concrete.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TelephoneTypesController : BaseController
    {
        private ITelephoneTypeService _telephoneTypeService;

        public TelephoneTypesController(ITelephoneTypeService telephoneTypeService)
        {
            _telephoneTypeService = telephoneTypeService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserTelephoneType userTelephoneType)
        {
            var result = await _telephoneTypeService.Add(userTelephoneType);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserTelephoneType userTelephoneType)
        {
            var result = await _telephoneTypeService.Update(userTelephoneType);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var result = await _telephoneTypeService.Delete(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _telephoneTypeService.GetAll();
            return Ok(result);
        }
    }
}
