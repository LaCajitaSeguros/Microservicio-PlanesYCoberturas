using Aplication.Interfaces.Categorias;
using Aplication.Requests.Categorias;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCases.Categorias
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaCommand _command;
        private readonly ICategoriaQuery _query;

        public CategoriaService(ICategoriaCommand command, ICategoriaQuery query)
        {
            _command = command;
            _query = query;
        }

        //public async Task<Categoria> CreateCategoria(CreateCategoriaRequest request)
        //{
        //    var categoria = new Categoria
        //    {
        //        Nombre = request.Nombre
        //    };
            
        //    await _command.InsertCategoria(categoria);
        //    return categoria;
        //}

        //public Task<Categoria> DeleteCategoria(int categoriaId)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<Categoria>> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<Categoria> GetById(int categoriaId)
        //{
        //    var categoria = await _query.GetCategoria(categoriaId);
        //    return categoria;
        //}

        //public Task<Categoria> UpdateCategoria(int categoriaId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
