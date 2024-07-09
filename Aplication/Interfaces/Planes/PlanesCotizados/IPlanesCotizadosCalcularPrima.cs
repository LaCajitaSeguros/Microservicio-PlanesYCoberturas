using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.Planes.PlanesCotizados
{
    public interface IPlanesCotizadosCalcularPrima
    {
        void CalcularPrima(int cotizacion, List<Plan> planes);
    }
}
