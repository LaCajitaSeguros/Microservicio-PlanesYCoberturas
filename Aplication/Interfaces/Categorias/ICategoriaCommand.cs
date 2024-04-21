using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.Categorias
{
    public interface ICategoriaCommand
    {
        //Task InsertCategoria(Categoria categoria);
        Task RemoveCategoria(int categoriaId);
    }
}
