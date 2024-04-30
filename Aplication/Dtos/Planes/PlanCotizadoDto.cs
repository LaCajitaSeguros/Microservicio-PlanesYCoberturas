using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos.Planes
{
    public class PlanCotizadoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Prima { get; set; }
        public List<PlanCoberturaDto> Coberturas { get; set; }
    }
}
