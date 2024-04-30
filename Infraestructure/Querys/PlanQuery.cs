using Aplication.Interfaces.Planes;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Querys
{
    public class PlanQuery : IPlanQuery
    {
        private readonly PlanesContext _context;

        public PlanQuery(PlanesContext context)
        {
            _context = context;
        }
        public async Task<List<Plan>> ObtenerPlanPorCotizacion(int cotizacion)
        {
            var qeury = _context.Plan
               .Include(p => p.Criterios.Where(c => c.Criterio.CotizacionMinima >= cotizacion && c.Criterio.CotizacionMaxima <= cotizacion))
               .ToQueryString();

            var planes = await _context.Plan
                .Where(p => p.Criterios.Any(c => c.Criterio.CotizacionMinima <= cotizacion && c.Criterio.CotizacionMaxima >= cotizacion))
                .Include(p => p.Criterios).ThenInclude(c => c.Criterio)
                .Include(p => p.Coberturas).ThenInclude(c => c.Cobertura)
                .ToListAsync();

            return planes;
        }

        public async Task<Plan> ObtenerPlanPorId(int id)
        {
            var plan = await _context.Plan
                .Where(p => p.Id == id)
                .Include(p => p.Coberturas).ThenInclude(c => c.Cobertura)
                .FirstOrDefaultAsync();

            return plan;
        }
    }
}
