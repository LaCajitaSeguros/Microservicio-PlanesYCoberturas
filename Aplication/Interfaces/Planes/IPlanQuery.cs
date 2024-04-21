using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.Planes
{
    public interface IPlanQuery
    {
        Task<List<Plan>> ObtenerPlanPorCotizacion(int cotizacion);
    }
}
