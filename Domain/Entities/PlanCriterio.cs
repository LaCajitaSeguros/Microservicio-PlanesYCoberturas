using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PlanCriterio
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public int CriterioId { get; set; }
        public int PorcentajeAumento { get; set; }
        public Criterio Criterio { get; set; }
        public Plan Plan { get; set; }
    }
}
