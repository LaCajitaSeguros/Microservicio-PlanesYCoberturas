using Aplication.Interfaces.Planes.PlanesCotizados;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCases.Planes.PlanesCotizados
{
    public class PlanesCotizadosCalcularPrima : IPlanesCotizadosCalcularPrima
    {
        public void CalcularPrima(int cotizacion, List<Plan> planes)
        {
            foreach (var plan in planes)
            {
                decimal porcentajeAumento = Convert.ToDecimal(plan.Criterios.FirstOrDefault().PorcentajeAumento) / 100;
                decimal recargo = porcentajeAumento * cotizacion;
                decimal prima = cotizacion + recargo;
                plan.SetPrima(prima);
            }
        }
    }
}
