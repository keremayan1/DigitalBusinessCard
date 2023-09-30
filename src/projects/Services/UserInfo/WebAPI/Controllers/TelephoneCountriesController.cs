using Application.Services.TelephoneCountry;
using Core.Shared.BaseController;
using Domain.Concrete.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TelephoneCountriesController : BaseController
    {
        private ITelephoneCountryService _telephoneCountryService;

        public TelephoneCountriesController(ITelephoneCountryService telephoneCountryService)
        {
            _telephoneCountryService = telephoneCountryService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UserTelephoneCountry userTelephoneCountry)
        {
            var result = await _telephoneCountryService.Add(userTelephoneCountry);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserTelephoneCountry userTelephoneCountry)
        {
            var result = await _telephoneCountryService.Update(userTelephoneCountry);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var result = await _telephoneCountryService.Delete(id);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _telephoneCountryService.GetAll();
            return Ok(result);
        }
    }
}
