using Aplication.Interfaces.Categorias;
using Aplication.Interfaces.Planes;
using Aplication.Requests.Categorias;
using Aplication.Requests.Planes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Planes.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PlanesController : ControllerBase
    {
        private readonly IPlanService _service;

        public PlanesController(IPlanService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> PlanesCotizados([FromQuery]PlanesCotizadosRequest request)
        {
            var result = await _service.PlanesCotizadados(request);
            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarPLan([FromQuery] BuscarPlanRequest request)
        {
            var result = await _service.BuscarPlan(request);
            return new JsonResult(result);
        }
    }
}
