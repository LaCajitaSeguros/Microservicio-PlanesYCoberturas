using Aplication.Requests.Planes;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.Planes.PlanesCotizados
{
    public interface IPlanesCotizadosValidaciones
    {
        Error Validaciones(PlanesCotizadosRequest request, List<Plan> planes);
    }
}
