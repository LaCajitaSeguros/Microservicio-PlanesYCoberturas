using Aplication.Interfaces.Categorias;
using Domain.Entities;
using Infraestructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Commands
{
    public class CategoriaCommand : ICategoriaCommand
    {
        private readonly PlanesContext _context;

        public CategoriaCommand(PlanesContext context)
        {
            _context = context;
        }

        //public async Task InsertCategoria(Categoria categoria)
        //{
        //    _context.Add(categoria);

        //    await _context.SaveChangesAsync();
        //}

        public Task RemoveCategoria(int categoriaId)
        {
            throw new NotImplementedException();
        }
    }
}
