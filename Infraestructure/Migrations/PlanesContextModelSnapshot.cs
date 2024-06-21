﻿// <auto-generated />
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infraestructure.Migrations
{
    [DbContext(typeof(PlanesContext))]
    partial class PlanesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Cobertura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cobertura");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Responsabilidad Civil"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Protección al conductor"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Asistencia al viajero"
                        },
                        new
                        {
                            Id = 4,
                            Descripcion = "Monto asegurado actualizado"
                        },
                        new
                        {
                            Id = 5,
                            Descripcion = "Robo Total y Parcial"
                        },
                        new
                        {
                            Id = 6,
                            Descripcion = "Destrucción Total"
                        },
                        new
                        {
                            Id = 7,
                            Descripcion = "Incendio Total y Parcial"
                        },
                        new
                        {
                            Id = 8,
                            Descripcion = "Cristales y Cerraduras sin límite"
                        },
                        new
                        {
                            Id = 9,
                            Descripcion = "Cubiertas y llantas (por robo)"
                        },
                        new
                        {
                            Id = 10,
                            Descripcion = "Granizo"
                        },
                        new
                        {
                            Id = 11,
                            Descripcion = "Servicio de auxilio y remolque"
                        },
                        new
                        {
                            Id = 12,
                            Descripcion = "Reposición 0Km"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Criterio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CotizacionMaxima")
                        .HasColumnType("int");

                    b.Property<int>("CotizacionMinima")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Criterio");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CotizacionMaxima = 100000,
                            CotizacionMinima = 0
                        },
                        new
                        {
                            Id = 2,
                            CotizacionMaxima = 200000,
                            CotizacionMinima = 100001
                        },
                        new
                        {
                            Id = 3,
                            CotizacionMaxima = 300000,
                            CotizacionMinima = 200001
                        },
                        new
                        {
                            Id = 4,
                            CotizacionMaxima = 400000,
                            CotizacionMinima = 300001
                        },
                        new
                        {
                            Id = 5,
                            CotizacionMaxima = 500000,
                            CotizacionMinima = 400001
                        });
                });

            modelBuilder.Entity("Domain.Entities.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Plan");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descripcion = "Es la cobertura básica y obligatoria para que todo automotor pueda circular, protegiendo al titular por los daños que el vehículo pueda ocasionar a terceros.",
                            Nombre = "Plan Basico"
                        },
                        new
                        {
                            Id = 2,
                            Descripcion = "Nuestro seguro para autos es perfecto para estar preparado ante los imprevistos de la calle. Es el indicado para quienes quieren un nivel de protección alto a un precio moderado.",
                            Nombre = "Plan Intermedio"
                        },
                        new
                        {
                            Id = 3,
                            Descripcion = "Es el seguro ideal para quienes prestan especial atención a los detalles y quieren la mejor protección para su vehículo. Es la cobertura por excelencia y la más completa de nuestro portfolio.",
                            Nombre = "Plan Full"
                        });
                });

            modelBuilder.Entity("Domain.Entities.PlanCobertura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CoberturaId")
                        .HasColumnType("int");

                    b.Property<int>("PlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoberturaId");

                    b.HasIndex("PlanId");

                    b.ToTable("PlanCobertura");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CoberturaId = 1,
                            PlanId = 1
                        },
                        new
                        {
                            Id = 2,
                            CoberturaId = 2,
                            PlanId = 1
                        },
                        new
                        {
                            Id = 3,
                            CoberturaId = 3,
                            PlanId = 1
                        },
                        new
                        {
                            Id = 4,
                            CoberturaId = 4,
                            PlanId = 1
                        },
                        new
                        {
                            Id = 5,
                            CoberturaId = 1,
                            PlanId = 2
                        },
                        new
                        {
                            Id = 6,
                            CoberturaId = 2,
                            PlanId = 2
                        },
                        new
                        {
                            Id = 7,
                            CoberturaId = 3,
                            PlanId = 2
                        },
                        new
                        {
                            Id = 8,
                            CoberturaId = 4,
                            PlanId = 2
                        },
                        new
                        {
                            Id = 9,
                            CoberturaId = 5,
                            PlanId = 2
                        },
                        new
                        {
                            Id = 10,
                            CoberturaId = 6,
                            PlanId = 2
                        },
                        new
                        {
                            Id = 11,
                            CoberturaId = 7,
                            PlanId = 2
                        },
                        new
                        {
                            Id = 12,
                            CoberturaId = 8,
                            PlanId = 2
                        },
                        new
                        {
                            Id = 13,
                            CoberturaId = 1,
                            PlanId = 3
                        },
                        new
                        {
                            Id = 14,
                            CoberturaId = 2,
                            PlanId = 3
                        },
                        new
                        {
                            Id = 15,
                            CoberturaId = 3,
                            PlanId = 3
                        },
                        new
                        {
                            Id = 16,
                            CoberturaId = 4,
                            PlanId = 3
                        },
                        new
                        {
                            Id = 17,
                            CoberturaId = 5,
                            PlanId = 3
                        },
                        new
                        {
                            Id = 18,
                            CoberturaId = 6,
                            PlanId = 3
                        },
                        new
                        {
                            Id = 19,
                            CoberturaId = 7,
                            PlanId = 3
                        },
                        new
                        {
                            Id = 20,
                            CoberturaId = 8,
                            PlanId = 3
                        },
                        new
                        {
                            Id = 21,
                            CoberturaId = 9,
                            PlanId = 3
                        },
                        new
                        {
                            Id = 22,
                            CoberturaId = 10,
                            PlanId = 3
                        },
                        new
                        {
                            Id = 23,
                            CoberturaId = 11,
                            PlanId = 3
                        },
                        new
                        {
                            Id = 24,
                            CoberturaId = 12,
                            PlanId = 3
                        });
                });

            modelBuilder.Entity("Domain.Entities.PlanCriterio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CriterioId")
                        .HasColumnType("int");

                    b.Property<int>("PlanId")
                        .HasColumnType("int");

                    b.Property<int>("PorcentajeAumento")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CriterioId");

                    b.HasIndex("PlanId");

                    b.ToTable("PlanCriterio");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CriterioId = 1,
                            PlanId = 1,
                            PorcentajeAumento = 5
                        },
                        new
                        {
                            Id = 2,
                            CriterioId = 2,
                            PlanId = 1,
                            PorcentajeAumento = 7
                        },
                        new
                        {
                            Id = 3,
                            CriterioId = 3,
                            PlanId = 1,
                            PorcentajeAumento = 10
                        },
                        new
                        {
                            Id = 4,
                            CriterioId = 4,
                            PlanId = 1,
                            PorcentajeAumento = 12
                        },
                        new
                        {
                            Id = 5,
                            CriterioId = 5,
                            PlanId = 1,
                            PorcentajeAumento = 15
                        },
                        new
                        {
                            Id = 6,
                            CriterioId = 1,
                            PlanId = 2,
                            PorcentajeAumento = 17
                        },
                        new
                        {
                            Id = 7,
                            CriterioId = 2,
                            PlanId = 2,
                            PorcentajeAumento = 20
                        },
                        new
                        {
                            Id = 8,
                            CriterioId = 3,
                            PlanId = 2,
                            PorcentajeAumento = 23
                        },
                        new
                        {
                            Id = 9,
                            CriterioId = 4,
                            PlanId = 2,
                            PorcentajeAumento = 26
                        },
                        new
                        {
                            Id = 10,
                            CriterioId = 5,
                            PlanId = 2,
                            PorcentajeAumento = 29
                        },
                        new
                        {
                            Id = 11,
                            CriterioId = 1,
                            PlanId = 3,
                            PorcentajeAumento = 31
                        },
                        new
                        {
                            Id = 12,
                            CriterioId = 2,
                            PlanId = 3,
                            PorcentajeAumento = 34
                        },
                        new
                        {
                            Id = 13,
                            CriterioId = 3,
                            PlanId = 3,
                            PorcentajeAumento = 37
                        },
                        new
                        {
                            Id = 14,
                            CriterioId = 4,
                            PlanId = 3,
                            PorcentajeAumento = 40
                        },
                        new
                        {
                            Id = 15,
                            CriterioId = 5,
                            PlanId = 3,
                            PorcentajeAumento = 43
                        });
                });

            modelBuilder.Entity("Domain.Entities.PlanCobertura", b =>
                {
                    b.HasOne("Domain.Entities.Cobertura", "Cobertura")
                        .WithMany()
                        .HasForeignKey("CoberturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Plan", null)
                        .WithMany("Coberturas")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cobertura");
                });

            modelBuilder.Entity("Domain.Entities.PlanCriterio", b =>
                {
                    b.HasOne("Domain.Entities.Criterio", "Criterio")
                        .WithMany()
                        .HasForeignKey("CriterioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Plan", "Plan")
                        .WithMany("Criterios")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Criterio");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("Domain.Entities.Plan", b =>
                {
                    b.Navigation("Coberturas");

                    b.Navigation("Criterios");
                });
#pragma warning restore 612, 618
        }
    }
}
