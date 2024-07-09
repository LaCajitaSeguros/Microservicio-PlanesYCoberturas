using Aplication.Dtos.Planes;
using Aplication.Interfaces.Planes.PlanesCotizados;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCases.Planes.PlanesCotizados
{
    public class PlanesCotizadosMapper : IPlanesCotizadosMapper
    {
        public List<PlanCotizadoDto> Mapear(List<Plan> planes)
        {
            var planesDto = new List<PlanCotizadoDto>();
            foreach (var plan in planes)
            {
                var coberturasDto = new List<PlanCoberturaDto>();

                foreach (var cobertura in plan.Coberturas)
                {
                    var coberturaDto = new PlanCoberturaDto
                    {
                        Descripcion = cobertura.Cobertura.Descripcion
                    };

                    coberturasDto.Add(coberturaDto);
                }

                var planDto = new PlanCotizadoDto
                {
                    Id = plan.Id,
                    Nombre = plan.Nombre,
                    Descripcion = plan.Descripcion,
                    Prima = plan.ObtenerPrima(),
                    Coberturas = coberturasDto
                };

                planesDto.Add(planDto);
            }

            return planesDto;
        }
    }
}
