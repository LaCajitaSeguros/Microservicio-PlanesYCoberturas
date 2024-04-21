//using Aplication.Interfaces.Categorias;
//using Aplication.Requests.Categorias;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Planes.Controllers
//{
//    [Route("api/[controller]/[action]")]
//    [ApiController]
//    public class CategoriaController : ControllerBase
//    {
//        private readonly ICategoriaService _service;

//        public CategoriaController(ICategoriaService service)
//        {
//            _service = service;
//        }

//        [HttpGet]
//        public async Task<IActionResult> Estudiantes()
//        {
//            var result = await _service.GetAll();
//            return new JsonResult(result);
//        }

//        [HttpGet("{Id}")]
//        public async Task<IActionResult> GetById(int Id)
//        {
//            var result = await _service.GetById(Id);
//            return new JsonResult(result);
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateCategoria(CreateCategoriaRequest request)
//        {
//            var result = await _service.CreateCategoria(request);
//            return new JsonResult(result) {StatusCode = 201 };
//        }
//    }
//}
