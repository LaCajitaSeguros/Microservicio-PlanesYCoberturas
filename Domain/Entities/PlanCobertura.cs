using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PlanCobertura
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public int CoberturaId { get; set; }

        public Cobertura Cobertura { get; set; }
    }
}
