using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Interfaces.Products;
using Aplication.Requests.Categorias;
using Aplication.Requests.Products;
using AutoMapper;
using Domain.Entities;

namespace Aplication.UseCases.Products
{
    public class ProductService :IProductService
    {
        private readonly IProductCommand _command;
        private readonly IProductQuery _query;
        private readonly IMapper _mapper;

        public ProductService(IProductCommand command, IProductQuery query, IMapper mapper)
        {
            _command = command;
            _query = query;
            _mapper = mapper;
        }

        //public async Task<Producto> CreateProductAsync(CreateProductRequest request)
        //{
        //    var product = _mapper.Map<Producto>(request);
        //    product.Nuevo();

        //    await _command.InsertProduct(product);
        //    return product;
        //}
    }
}
