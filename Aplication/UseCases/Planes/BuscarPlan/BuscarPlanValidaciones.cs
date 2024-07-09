using Aplication.Interfaces.Planes.BuscarPlan;
using Aplication.Requests.Planes;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCases.Planes.BuscarPlan
{
    public class BuscarPlanValidaciones : IBuscarPlanValidaciones
    {
        public Error Validaciones(Plan plan, BuscarPlanRequest request)
        {
            if (plan is null)
            {
                return Error.NotFound($"No existe un plan con el Id {request.Id}");
            }

            else
            {
                return null;
            }
        }
    }
}
