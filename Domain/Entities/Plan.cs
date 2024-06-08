using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Plan
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        private decimal Prima {get;set;}

        public List<PlanCobertura> Coberturas { get; set; }
        public List<PlanCriterio> Criterios { get; set; }

        public void CalcularPrima(int cotizacion)
        {
            decimal porcentajeAumento = Convert.ToDecimal(Criterios.FirstOrDefault().PorcentajeAumento) / 100;
            decimal recargo = porcentajeAumento * cotizacion;
            Prima = cotizacion + recargo;
        }

        public decimal ObtenerPrima()
        {
            return Prima;
        }
    }
}
