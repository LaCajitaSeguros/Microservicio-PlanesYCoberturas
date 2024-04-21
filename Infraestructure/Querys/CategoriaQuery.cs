using Aplication.Interfaces.Categorias;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Querys
{
    public class CategoriaQuery : ICategoriaQuery
    {
        private readonly PlanesContext _context;

        public CategoriaQuery(PlanesContext context)
        {
            _context = context;
        }

        //public List<Categoria> GetAllCategorias()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<Categoria> GetCategoria(int categoriaId)
        //{
        //    var categoria = await _context.Categoria.FirstOrDefaultAsync(s => s.Id == categoriaId);
        //    return categoria;
        //}
    }
}
