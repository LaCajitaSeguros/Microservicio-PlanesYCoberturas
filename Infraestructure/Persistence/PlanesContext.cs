using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Infraestructure.Persistence
{
    public class PlanesContext : DbContext
    {
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Cobertura> Cobertura { get; set; }
        public DbSet<Criterio> Criterio { get; set; }
        public DbSet<PlanCobertura> PlanCobertura { get; set; }
        public DbSet<PlanCriterio> PlanCriterio { get; set; }


        public PlanesContext(DbContextOptions<PlanesContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Plan>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nombre);
            });

            modelBuilder.Entity<Cobertura>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Descripcion);
            });

            modelBuilder.Entity<Criterio>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CotizacionMinima);
                entity.Property(e => e.CotizacionMaxima);
            });

            modelBuilder.Entity<PlanCobertura>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PlanId);
                entity.Property(e => e.CoberturaId);
            });

            modelBuilder.Entity<PlanCriterio>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CriterioId);
                entity.Property(e => e.PlanId);
                entity.Property(e => e.PorcentajeAumento);
            });

            
            //INSERCION DE DATOS.
            modelBuilder.Entity<Plan>().HasData(
                new Plan { Id = 1, Nombre = "Plan Basico", Descripcion = "Es la cobertura básica y obligatoria para que todo automotor pueda circular, protegiendo al titular por los daños que el vehículo pueda ocasionar a terceros."},
                new Plan { Id = 2, Nombre = "Plan Intermedio", Descripcion = "Nuestro seguro para autos es perfecto para estar preparado ante los imprevistos de la calle. Es el indicado para quienes quieren un nivel de protección alto a un precio moderado."},
                new Plan { Id = 3, Nombre = "Plan Full", Descripcion = "Es el seguro ideal para quienes prestan especial atención a los detalles y quieren la mejor protección para su vehículo. Es la cobertura por excelencia y la más completa de nuestro portfolio."}
            );

            modelBuilder.Entity<Cobertura>().HasData(
                new Cobertura { Id = 1, Descripcion = "Responsabilidad Civil" },
                new Cobertura { Id = 2, Descripcion = "Protección al conductor" },
                new Cobertura { Id = 3, Descripcion = "Asistencia al viajero" },
                new Cobertura { Id = 4, Descripcion = "Monto asegurado actualizado" },
                new Cobertura { Id = 5, Descripcion = "Robo Total y Parcial" },
                new Cobertura { Id = 6, Descripcion = "Destrucción Total" },
                new Cobertura { Id = 7, Descripcion = "Incendio Total y Parcial" },
                new Cobertura { Id = 8, Descripcion = "Cristales y Cerraduras sin límite" },
                new Cobertura { Id = 9, Descripcion = "Cubiertas y llantas (por robo)" },
                new Cobertura { Id = 10, Descripcion = "Granizo" },
                new Cobertura { Id = 11, Descripcion = "Servicio de auxilio y remolque" },
                new Cobertura { Id = 12, Descripcion = "Reposición 0Km" }
            );

            modelBuilder.Entity<Criterio>().HasData(
                new Criterio { Id = 1, CotizacionMinima = 0, CotizacionMaxima = 20000 },
                new Criterio { Id = 2, CotizacionMinima = 20001, CotizacionMaxima = 30000 },
                new Criterio { Id = 3, CotizacionMinima = 30001, CotizacionMaxima = 40000 },
                new Criterio { Id = 4, CotizacionMinima = 40001, CotizacionMaxima = 50000 },
                new Criterio { Id = 5, CotizacionMinima = 50001, CotizacionMaxima = 60000 }
            );

            modelBuilder.Entity<PlanCobertura>().HasData(
                new PlanCobertura { Id = 1, PlanId = 1, CoberturaId = 1 },
                new PlanCobertura { Id = 2, PlanId = 1, CoberturaId = 2 }, 
                new PlanCobertura { Id = 3, PlanId = 1, CoberturaId = 3 },
                new PlanCobertura { Id = 4, PlanId = 1, CoberturaId = 4 },
                new PlanCobertura { Id = 5, PlanId = 2, CoberturaId = 1 },
                new PlanCobertura { Id = 6, PlanId = 2, CoberturaId = 2 },
                new PlanCobertura { Id = 7, PlanId = 2, CoberturaId = 3 },
                new PlanCobertura { Id = 8, PlanId = 2, CoberturaId = 4 },
                new PlanCobertura { Id = 9, PlanId = 2, CoberturaId = 5 },
                new PlanCobertura { Id = 10, PlanId = 2, CoberturaId = 6 },
                new PlanCobertura { Id = 11, PlanId = 2, CoberturaId = 7 },
                new PlanCobertura { Id = 12, PlanId = 2, CoberturaId = 8 },
                new PlanCobertura { Id = 13, PlanId = 3, CoberturaId = 1 },
                new PlanCobertura { Id = 14, PlanId = 3, CoberturaId = 2 },
                new PlanCobertura { Id = 15, PlanId = 3, CoberturaId = 3 },
                new PlanCobertura { Id = 16, PlanId = 3, CoberturaId = 4 },
                new PlanCobertura { Id = 17, PlanId = 3, CoberturaId = 5 },
                new PlanCobertura { Id = 18, PlanId = 3, CoberturaId = 6 },
                new PlanCobertura { Id = 19, PlanId = 3, CoberturaId = 7 },
                new PlanCobertura { Id = 20, PlanId = 3, CoberturaId = 8 },
                new PlanCobertura { Id = 21, PlanId = 3, CoberturaId = 9 },
                new PlanCobertura { Id = 22, PlanId = 3, CoberturaId = 10 },
                new PlanCobertura { Id = 23, PlanId = 3, CoberturaId = 11 },
                new PlanCobertura { Id = 24, PlanId = 3, CoberturaId = 12 }
            );

            modelBuilder.Entity<PlanCriterio>().HasData(
                new PlanCriterio { Id = 1, PlanId = 1, CriterioId = 1, PorcentajeAumento = 5 },
                new PlanCriterio { Id = 2, PlanId = 1, CriterioId = 2, PorcentajeAumento = 7 },
                new PlanCriterio { Id = 3, PlanId = 1, CriterioId = 3, PorcentajeAumento = 10 },
                new PlanCriterio { Id = 4, PlanId = 1, CriterioId = 4, PorcentajeAumento = 12 },
                new PlanCriterio { Id = 5, PlanId = 1, CriterioId = 5, PorcentajeAumento = 15 },
                new PlanCriterio { Id = 6, PlanId = 2, CriterioId = 1, PorcentajeAumento = 17 },
                new PlanCriterio { Id = 7, PlanId = 2, CriterioId = 2, PorcentajeAumento = 20 },
                new PlanCriterio { Id = 8, PlanId = 2, CriterioId = 3, PorcentajeAumento = 23 },
                new PlanCriterio { Id = 9, PlanId = 2, CriterioId = 4, PorcentajeAumento = 26 },
                new PlanCriterio { Id = 10, PlanId = 2, CriterioId = 5, PorcentajeAumento = 29 },
                new PlanCriterio { Id = 11, PlanId = 3, CriterioId = 1, PorcentajeAumento = 31 },
                new PlanCriterio { Id = 12, PlanId = 3, CriterioId = 2, PorcentajeAumento = 34 },
                new PlanCriterio { Id = 13, PlanId = 3, CriterioId = 3, PorcentajeAumento = 37 },
                new PlanCriterio { Id = 14, PlanId = 3, CriterioId = 4, PorcentajeAumento = 40 },
                new PlanCriterio { Id = 15, PlanId = 3, CriterioId = 5, PorcentajeAumento = 43 }
            );


        }
    }
}
