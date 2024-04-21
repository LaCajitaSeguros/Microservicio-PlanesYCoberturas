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
        public async Task<IActionResult> ListaPlanesCotizados([FromQuery]PlanListaCotizadaRequest request)
        {
            var result = await _service.PlanListaCotizada(request);
            return new JsonResult(result);
        }
    }
}
