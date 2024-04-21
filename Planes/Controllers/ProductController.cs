//using Aplication.Interfaces.Products;
//using Aplication.Requests.Products;
//using Microsoft.AspNetCore.Mvc;

//namespace Planes.Controllers
//{
//    [Route("api/[controller]/[action]")]
//    [ApiController]
//    public class ProductController : ControllerBase
//    {
//        private readonly IProductService _service;

//        public ProductController(IProductService service)
//        {
//            _service = service;
//        }

//        [HttpPost]
//        public async Task<IActionResult> CreateProducto(CreateProductRequest request)
//        {
//            var result =  _service.CreateProductAsync(request);
//            return new JsonResult(result) { StatusCode = 201 };
//        }
//    }
//}
