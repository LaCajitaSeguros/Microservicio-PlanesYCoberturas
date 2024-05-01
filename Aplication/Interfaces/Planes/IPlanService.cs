using Aplication.Dtos.Planes;
using Aplication.Requests.Planes;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.Planes
{
    public interface IPlanService
    {
        Task<Result> BuscarPlan(BuscarPlanRequest request);
        Task<Result> PlanesCotizadados(PlanesCotizadosRequest request);
    }
}
