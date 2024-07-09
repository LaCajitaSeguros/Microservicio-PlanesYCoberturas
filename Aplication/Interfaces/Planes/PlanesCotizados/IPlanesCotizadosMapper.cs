using Aplication.Dtos.Planes;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.Planes.PlanesCotizados
{
    public interface IPlanesCotizadosMapper
    {
        List<PlanCotizadoDto> Mapear(List<Plan> planes);
    }
}
