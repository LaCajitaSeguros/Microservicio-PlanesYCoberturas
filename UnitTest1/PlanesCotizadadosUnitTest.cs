using Aplication.Dtos.Planes;
using Aplication.Interfaces.Planes;
using Aplication.Requests.Planes;
using Aplication.UseCases.Planes.BuscarPlan;
using Aplication.UseCases.Planes;
using AutoMapper;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Aplication.UseCases.Planes.PlanesCotizados;
using Aplication.Interfaces.Planes.BuscarPlan;
using Aplication.Interfaces.Planes.PlanesCotizados;
using System.Numerics;
using Aplication;
using Error = Aplication.Error;

namespace UnitTest
{
    public class PlanesCotizadadosUnitTest
    {
        [Fact]
        public async Task PlanesCotizadados_CalcularPrima_ShouldBeCorrect()
        {
            //Arrange.
            var mockQuery = new Mock<IPlanQuery>();
            var mockMapper = new Mock<IMapper>();
            var mockBuscarPlanValidaciones = new Mock<IBuscarPlanValidaciones>();
            var mockPlanesCotizadosValidaciones = new Mock<IPlanesCotizadosValidaciones>();
            var calcularPrima = new PlanesCotizadosCalcularPrima();
            var mapper = new PlanesCotizadosMapper();
            var service = new PlanService(mockQuery.Object, mockMapper.Object, mockBuscarPlanValidaciones.Object, mockPlanesCotizadosValidaciones.Object, calcularPrima, mapper);
            var planes = CrearPlanes();
            var cotizacion = 20000;

            mockQuery.Setup(q => q.ObtenerPlanPorCotizacion(It.IsAny<int>())).ReturnsAsync(planes);

            var request = new PlanesCotizadosRequest
            {
                Cotizacion = cotizacion
            };

            CalcularPrima(cotizacion, planes);
            var planesDto = Mapear(planes);

            //Act
            var result = await service.PlanesCotizadados(request);

            //Assert
            var resultPlanesDto = result.Data.As<List<PlanCotizadoDto>>();
            resultPlanesDto.Should().BeEquivalentTo(planesDto);
        }

        [Fact]
        public async Task PlanesCotizadados_ShouldReturnSuccess_200()
        {
            //Arrange.
            var mockQuery = new Mock<IPlanQuery>();
            var mockMapper = new Mock<IMapper>();
            var mockBuscarPlanValidaciones = new Mock<IBuscarPlanValidaciones>();
            var mockPlanesCotizadosCalcularPrima = new Mock<IPlanesCotizadosCalcularPrima>();
            var mockPlanesCotizadosMapper = new Mock<IPlanesCotizadosMapper>();
            var mockPlanesCotizadosValidaciones = new Mock<IPlanesCotizadosValidaciones>();
            var service = new PlanService(mockQuery.Object, mockMapper.Object, mockBuscarPlanValidaciones.Object, mockPlanesCotizadosValidaciones.Object, mockPlanesCotizadosCalcularPrima.Object, mockPlanesCotizadosMapper.Object);

            var planes = CrearPlanes();
            List<PlanCotizadoDto> planesDto = new List<PlanCotizadoDto>();

            mockQuery.Setup(q => q.ObtenerPlanPorCotizacion(It.IsAny<int>())).ReturnsAsync(planes);
            mockMapper.Setup(q => q.Map<List<PlanCotizadoDto>>(planes)).Returns(planesDto);

            var request = new PlanesCotizadosRequest
            {
                Cotizacion = 10000
            };

            mockPlanesCotizadosValidaciones.Setup(q => q.Validaciones(request, planes)).Returns((Error)null);


            //Act
            var result = await service.PlanesCotizadados(request);

            //Assert
            result.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task PlanesCotizadados_ShouldReturnBadRequest_400()
        {
            //Arrange.
            var mockQuery = new Mock<IPlanQuery>();
            var mockMapper = new Mock<IMapper>();
            var mockBuscarPlanValidaciones = new Mock<IBuscarPlanValidaciones>();
            var mockPlanesCotizadosCalcularPrima = new Mock<IPlanesCotizadosCalcularPrima>();
            var mockPlanesCotizadosMapper = new Mock<IPlanesCotizadosMapper>();
            var validaciones = new PlanesCotizadosValidaciones();
            var service = new PlanService(mockQuery.Object, mockMapper.Object, mockBuscarPlanValidaciones.Object, validaciones, mockPlanesCotizadosCalcularPrima.Object, mockPlanesCotizadosMapper.Object);

            List<Plan> planes = new List<Plan>();
            List<PlanCotizadoDto> planesDto = new List<PlanCotizadoDto>();

            mockQuery.Setup(q => q.ObtenerPlanPorCotizacion(It.IsAny<int>())).ReturnsAsync(planes);
            mockMapper.Setup(q => q.Map<List<PlanCotizadoDto>>(planes)).Returns(planesDto);

            var request = new PlanesCotizadosRequest
            {
                Cotizacion = 0
            };

            //Act
            var result = await service.PlanesCotizadados(request);

            //Assert
            result.HttpStatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task PlanesCotizadados_ShouldReturnNotFound_404()
        {
            //Arrange.
            var mockQuery = new Mock<IPlanQuery>();
            var mockMapper = new Mock<IMapper>();
            var mockBuscarPlanValidaciones = new Mock<IBuscarPlanValidaciones>();
            var mockPlanesCotizadosCalcularPrima = new Mock<IPlanesCotizadosCalcularPrima>();
            var mockPlanesCotizadosMapper = new Mock<IPlanesCotizadosMapper>();
            var validaciones = new PlanesCotizadosValidaciones();
            var service = new PlanService(mockQuery.Object, mockMapper.Object, mockBuscarPlanValidaciones.Object, validaciones, mockPlanesCotizadosCalcularPrima.Object, mockPlanesCotizadosMapper.Object);

            List<Plan> planes = new List<Plan>();
            List<PlanCotizadoDto> planesDto = new List<PlanCotizadoDto>();

            mockQuery.Setup(q => q.ObtenerPlanPorCotizacion(It.IsAny<int>())).ReturnsAsync(planes);
            mockMapper.Setup(q => q.Map<List<PlanCotizadoDto>>(planes)).Returns(planesDto);

            var request = new PlanesCotizadosRequest
            {
                Cotizacion = 120
            };

            //Act
            var result = await service.PlanesCotizadados(request);

            //Assert
            result.HttpStatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        public List<Plan> CrearPlanes()
        {

            var cobertura1 = new Cobertura { Id = 1, Descripcion = "Responsabilidad Civil" };
            var cobertura2 = new Cobertura { Id = 2, Descripcion = "Protección al conductor" };
            var cobertura3 = new Cobertura { Id = 3, Descripcion = "Asistencia al viajero" };
            var cobertura4 = new Cobertura { Id = 4, Descripcion = "Monto asegurado actualizado" };
            var cobertura5 = new Cobertura { Id = 5, Descripcion = "Robo Total y Parcial" };
            var cobertura6 = new Cobertura { Id = 6, Descripcion = "Destrucción Total" };
            var cobertura7 = new Cobertura { Id = 7, Descripcion = "Incendio Total y Parcial" };
            var cobertura8 = new Cobertura { Id = 8, Descripcion = "Cristales y Cerraduras sin límite" };
            var cobertura9 = new Cobertura { Id = 9, Descripcion = "Cubiertas y llantas (por robo)" };
            var cobertura10 = new Cobertura { Id = 10, Descripcion = "Granizo" };
            var cobertura11 = new Cobertura { Id = 11, Descripcion = "Servicio de auxilio y remolque" };
            var cobertura12 = new Cobertura { Id = 12, Descripcion = "Reposición 0Km" };

            var planCobertura1 = new List<PlanCobertura>
            {
                new PlanCobertura { Id = 1, PlanId = 1, CoberturaId = 1, Cobertura = cobertura1},
                new PlanCobertura { Id = 2, PlanId = 1, CoberturaId = 2, Cobertura = cobertura2 },
                new PlanCobertura { Id = 3, PlanId = 1, CoberturaId = 3, Cobertura = cobertura3 },
                new PlanCobertura { Id = 4, PlanId = 1, CoberturaId = 4, Cobertura = cobertura4 },
            };

            var planCobertura2 = new List<PlanCobertura>
            {
                new PlanCobertura { Id = 5, PlanId = 2, CoberturaId = 1, Cobertura = cobertura1 },
                new PlanCobertura { Id = 6, PlanId = 2, CoberturaId = 2, Cobertura = cobertura2 },
                new PlanCobertura { Id = 7, PlanId = 2, CoberturaId = 3, Cobertura = cobertura3 },
                new PlanCobertura { Id = 8, PlanId = 2, CoberturaId = 4, Cobertura = cobertura4 },
                new PlanCobertura { Id = 9, PlanId = 2, CoberturaId = 5, Cobertura = cobertura5 },
                new PlanCobertura { Id = 10, PlanId = 2, CoberturaId = 6, Cobertura = cobertura6 },
                new PlanCobertura { Id = 11, PlanId = 2, CoberturaId = 7, Cobertura = cobertura7 },
                new PlanCobertura { Id = 12, PlanId = 2, CoberturaId = 8, Cobertura = cobertura8 },
            };

            var planCobertura3 = new List<PlanCobertura>
            {
                new PlanCobertura { Id = 13, PlanId = 3, CoberturaId = 1, Cobertura = cobertura1 },
                new PlanCobertura { Id = 14, PlanId = 3, CoberturaId = 2, Cobertura = cobertura2 },
                new PlanCobertura { Id = 15, PlanId = 3, CoberturaId = 3, Cobertura = cobertura3 },
                new PlanCobertura { Id = 16, PlanId = 3, CoberturaId = 4, Cobertura = cobertura4 },
                new PlanCobertura { Id = 17, PlanId = 3, CoberturaId = 5, Cobertura = cobertura5 },
                new PlanCobertura { Id = 18, PlanId = 3, CoberturaId = 6, Cobertura = cobertura6 },
                new PlanCobertura { Id = 19, PlanId = 3, CoberturaId = 7, Cobertura = cobertura7 },
                new PlanCobertura { Id = 20, PlanId = 3, CoberturaId = 8, Cobertura = cobertura8 },
                new PlanCobertura { Id = 21, PlanId = 3, CoberturaId = 9 , Cobertura = cobertura9},
                new PlanCobertura { Id = 22, PlanId = 3, CoberturaId = 10, Cobertura = cobertura10 },
                new PlanCobertura { Id = 23, PlanId = 3, CoberturaId = 11, Cobertura = cobertura11 },
                new PlanCobertura { Id = 24, PlanId = 3, CoberturaId = 12 , Cobertura = cobertura12}
            };


            var planCriterio1 = new List<PlanCriterio>
            {
                new PlanCriterio { Id = 1, PlanId = 1, CriterioId = 1, PorcentajeAumento = 5 },
                new PlanCriterio { Id = 2, PlanId = 1, CriterioId = 2, PorcentajeAumento = 7 },
                new PlanCriterio { Id = 3, PlanId = 1, CriterioId = 3, PorcentajeAumento = 10 },
                new PlanCriterio { Id = 4, PlanId = 1, CriterioId = 4, PorcentajeAumento = 12 },
                new PlanCriterio { Id = 5, PlanId = 1, CriterioId = 5, PorcentajeAumento = 15 }

            };

            var planCriterio2 = new List<PlanCriterio>
            {
                new PlanCriterio { Id = 6, PlanId = 2, CriterioId = 1, PorcentajeAumento = 17 },
                new PlanCriterio { Id = 7, PlanId = 2, CriterioId = 2, PorcentajeAumento = 20 },
                new PlanCriterio { Id = 8, PlanId = 2, CriterioId = 3, PorcentajeAumento = 23 },
                new PlanCriterio { Id = 9, PlanId = 2, CriterioId = 4, PorcentajeAumento = 26 },
                new PlanCriterio { Id = 10, PlanId = 2, CriterioId = 5, PorcentajeAumento = 29 }
            };

            var planCriterio3 = new List<PlanCriterio>
            {
                new PlanCriterio { Id = 11, PlanId = 3, CriterioId = 1, PorcentajeAumento = 31 },
                new PlanCriterio { Id = 12, PlanId = 3, CriterioId = 2, PorcentajeAumento = 34 },
                new PlanCriterio { Id = 13, PlanId = 3, CriterioId = 3, PorcentajeAumento = 37 },
                new PlanCriterio { Id = 14, PlanId = 3, CriterioId = 4, PorcentajeAumento = 40 },
                new PlanCriterio { Id = 15, PlanId = 3, CriterioId = 5, PorcentajeAumento = 43 }
            };

            var planes = new List<Plan>
            {
                new Plan
                {
                    Id = 1,
                    Nombre = "Basico",
                    Descripcion = "Plan que cubre todas las coberturas",
                    Criterios = planCriterio1,
                    Coberturas = planCobertura1
                },
                new Plan
                {
                    Id = 2,
                    Nombre = "Medio",
                    Descripcion = "Plan con cobertura media",
                    Criterios = planCriterio2,
                    Coberturas = planCobertura2

                },
                new Plan
                {
                    Id = 3,
                    Nombre = "Full",
                    Descripcion = "Plan con cobertura full",
                    Criterios = planCriterio3,
                    Coberturas = planCobertura3

                }
            };

            return planes;
        }

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
