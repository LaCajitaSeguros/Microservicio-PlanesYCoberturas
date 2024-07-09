using Aplication.Interfaces.Planes.PlanesCotizados;
using Aplication.Requests.Planes;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCases.Planes.PlanesCotizados
{
    public class PlanesCotizadosValidaciones : IPlanesCotizadosValidaciones
    {
        public Error Validaciones(PlanesCotizadosRequest request, List<Plan> planes)
        {
            if (request.Cotizacion == 0)
            {
                return Error.BadRequest("La cotizacion no puede ser 0");
            }

            if (planes.Count == 0)
            {
                return Error.NotFound("No se encontraron planes");
            }

            return null;
        }
    }
}
