using Aplication.Dtos.Planes;
using Aplication.Interfaces.Planes;
using Aplication.Interfaces.Products;
using Aplication.Requests.Planes;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCases.Planes
{
    public class PlanService : IPlanService
    {
        private readonly IPlanQuery _query;
        private readonly IMapper _mapper;

        public PlanService(IPlanQuery query, IMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public async Task<Result> PlanesCotizadados(PlanesCotizadosRequest request)
        {

            var planes = await _query.ObtenerPlanPorCotizacion(request.Cotizacion);

            foreach (var plan in planes)
            {
                plan.CalcularPrima(request.Cotizacion);
            }

            var planesDto = _mapper.Map<List<PlanCotizadoDto>>(planes);

            return new Result(planesDto, HttpStatusCode.OK);
        }

        public async Task<Result> BuscarPlan(BuscarPlanRequest request)
        {
            var plan = await _query.ObtenerPlanPorId(request.Id);
            var error = Validaciones(plan, request);

            if (error is not null)
            {
                return new Result(error, HttpStatusCode.BadRequest);
            }

            else
            {
                var planDto = _mapper.Map<PlanDto>(plan);
                return new Result(planDto, HttpStatusCode.OK);
            }
        }

        public Error Validaciones(Plan plan, BuscarPlanRequest request)
        {
            if (plan is null)
            {
                return new Error($"No existe un plan con el Id {request.Id}");
            }

            else
            {
                return null;
            }
        }
    }
}
