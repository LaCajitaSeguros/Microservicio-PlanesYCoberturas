using Aplication.Dtos.Planes;
using Aplication.Interfaces.Planes;
using Aplication.Interfaces.Planes.BuscarPlan;
using Aplication.Interfaces.Planes.PlanesCotizados;
using Aplication.Interfaces.Products;
using Aplication.Requests.Planes;
using Aplication.UseCases.Planes.PlanesCotizados;
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
        private readonly IBuscarPlanValidaciones _buscarPlanValidaciones;
        private readonly IPlanesCotizadosValidaciones _planesCotizadosValidaciones;
        private readonly IPlanesCotizadosCalcularPrima _planesCotizadosCalcularPrima;
        private readonly IPlanesCotizadosMapper _planesCotizadosMapper;

        public PlanService(IPlanQuery query, IMapper mapper, IBuscarPlanValidaciones buscarPlanValidaciones, IPlanesCotizadosValidaciones planesCotizadosValidaciones, IPlanesCotizadosCalcularPrima planesCotizadosCalcularPrima, IPlanesCotizadosMapper planesCotizadosMapper)
        {
            _query = query;
            _mapper = mapper;
            _buscarPlanValidaciones = buscarPlanValidaciones;
            _planesCotizadosValidaciones = planesCotizadosValidaciones;
            _planesCotizadosCalcularPrima = planesCotizadosCalcularPrima;
            _planesCotizadosMapper = planesCotizadosMapper;
        }

        public async Task<Result> PlanesCotizadados(PlanesCotizadosRequest request)
        {
            var planes = await _query.ObtenerPlanPorCotizacion(request.Cotizacion);
            var error = _planesCotizadosValidaciones.Validaciones(request, planes);

            if (error is not null)
            {
                return Result.Error(error);
            }

            _planesCotizadosCalcularPrima.CalcularPrima(request.Cotizacion, planes);
            var planesDto = _planesCotizadosMapper.Mapear(planes);
            return Result.SuccessOk(planesDto);
        }

        public async Task<Result> BuscarPlan(BuscarPlanRequest request)
        {
            var plan = await _query.ObtenerPlanPorId(request.Id);
            var error = _buscarPlanValidaciones.Validaciones(plan, request);

            if (error is not null)
            {
                return Result.Error(error);
            }

            else
            {
                var planDto = _mapper.Map<PlanDto>(plan);
                return Result.SuccessOk(planDto);
            }
        }

    }
}
