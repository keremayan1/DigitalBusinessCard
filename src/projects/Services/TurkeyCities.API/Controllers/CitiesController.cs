using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TurkeyCities.API.Application.Services.CityService;

namespace TurkeyCities.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private IProvinceService _provinceService;

        public CitiesController(IProvinceService provinceService)
        {
            _provinceService = provinceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _provinceService.GetAll();
            return Ok(result);
        }
        [HttpGet]
        public async  Task<IActionResult> GetById(int id)
        {
            var result = await _provinceService.GetByProvinceId(id);
            return Ok(result);
        }

    }
}
