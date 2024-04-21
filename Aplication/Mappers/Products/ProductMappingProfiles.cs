using Aplication.Requests.Products;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mappers.Products
{
    public class ProductMappingProfiles : Profile
    {
        public ProductMappingProfiles()
        {
            //CreateMap<CreateProductRequest, Producto>();
        }
    }
}
