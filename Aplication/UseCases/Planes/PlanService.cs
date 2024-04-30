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

        public async Task<List<PlanCotizadoDto>> PlanesCotizadados(PlanesCotizadosRequest request)
        {

                var planes = await _query.ObtenerPlanPorCotizacion(request.Cotizacion);

                foreach (var plan in planes)
                {
                    plan.CalcularPrima(request.Cotizacion);
                }   

                var planesDto = _mapper.Map<List<PlanCotizadoDto>>(planes);
                return planesDto;        
        }
        
        public async Task<PlanDto> BuscarPlan(BuscarPlanRequest request)
        {
                var plan = await _query.ObtenerPlanPorId(request.Id);
                Validacion(plan, request);

                var planDto = _mapper.Map<PlanDto>(plan);
                return planDto;         
        }

        public void Validacion(Plan plan, BuscarPlanRequest request)
        {
            if(plan is null)
            {
                throw new Exception($"No existe un plan con el Id {request.Id}");
            }
        }
    }
}
