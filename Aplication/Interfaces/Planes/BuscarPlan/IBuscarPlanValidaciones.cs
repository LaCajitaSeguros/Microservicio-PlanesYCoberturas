using Aplication.Requests.Planes;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.Planes.BuscarPlan
{
    public interface IBuscarPlanValidaciones
    {
        Error Validaciones(Plan plan, BuscarPlanRequest request);
    }
}
