using Aplication.Dtos.Planes;
using Aplication.Interfaces.Planes;
using Aplication.Interfaces.Products;
using Aplication.Requests.Planes;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<PlanDto>> PlanListaCotizada(PlanListaCotizadaRequest request)
        {
            try
            {
                var planes = await _query.ObtenerPlanPorCotizacion(request.Cotizacion);

                foreach (var plan in planes)
                {
                    plan.CalcularPrima(request.Cotizacion);
                }   

                var planesDto = _mapper.Map<List<PlanDto>>(planes);
                //await _command.InsertProduct(product);
                return planesDto;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
