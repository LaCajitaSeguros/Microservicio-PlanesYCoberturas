using Aplication.Interfaces.Products;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Commands
{
    public class ProductCommand : IProductCommand
    {
        private readonly PlanesContext _context;

        public ProductCommand(PlanesContext context)
        {
            _context = context;
        }

        //public async Task InsertProduct(Producto product)
        //{
        //    _context.Add(product);

        //    await _context.SaveChangesAsync();
        //}
    }
}
