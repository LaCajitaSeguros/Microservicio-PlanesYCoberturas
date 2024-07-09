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

namespace UnitTest
{
    public class PlanesCotizadadosUnitTest
    {
        [Fact]
        public async Task PlanesCotizadados_ShouldReturnSuccess_200()
        {
            //Arrange.
            var mockQuery = new Mock<IPlanQuery>();
            var mockMapper = new Mock<IMapper>();
            var mockBuscarPlanValidaciones = new Mock<IBuscarPlanValidaciones>();
            var mockPlanesCotizadosValidaciones = new Mock<IPlanesCotizadosValidaciones>();
            var calcularPrima = new PlanesCotizadosCalcularPrima();
            var service = new PlanService(mockQuery.Object, mockMapper.Object, mockBuscarPlanValidaciones.Object, mockPlanesCotizadosValidaciones.Object, calcularPrima);

            var planes = new List<Plan>
            {
                new Plan
                {
                    Nombre = "Basico",
                    Descripcion = "Plan que cubre todas las coberturas"
                },
                new Plan
                {
                    Nombre = "Medio",
                    Descripcion = "Plan con cobertura media"
                },
                new Plan
                {
                    Nombre = "Full",
                    Descripcion = "Plan con cobertura full"
                }
            };

            var planesDto = new List<PlanCotizadoDto>
            {
                new PlanCotizadoDto
                {
                    Nombre = "Basico",
                    Descripcion = "Plan que cubre todas las coberturas"
                },
                new PlanCotizadoDto
                {
                    Nombre = "Medio",
                    Descripcion = "Plan con cobertura media"
                },
                new PlanCotizadoDto
                {
                    Nombre = "Full",
                    Descripcion = "Plan con cobertura full"
                }
            };

            mockQuery.Setup(q => q.ObtenerPlanPorCotizacion(It.IsAny<int>())).ReturnsAsync(planes);
            mockMapper.Setup(q => q.Map<List<PlanCotizadoDto>>(planes)).Returns(planesDto);

            var request = new PlanesCotizadosRequest
            {
                Cotizacion = 20000
            };

            //Act
            var result = await service.PlanesCotizadados(request);

            //Assert
            result.HttpStatusCode.Should().Be(HttpStatusCode.BadRequest);

        }

        [Fact]
        public async Task PlanesCotizadados_ShouldReturnBadRequest_400()
        {
            //Arrange.
            var mockQuery = new Mock<IPlanQuery>();
            var mockMapper = new Mock<IMapper>();
            var mockBuscarPlanValidaciones = new Mock<IBuscarPlanValidaciones>();
            var mockPlanesCotizadosCalcularPrima = new Mock<IPlanesCotizadosCalcularPrima>();
            var validaciones = new PlanesCotizadosValidaciones();
            var service = new PlanService(mockQuery.Object, mockMapper.Object, mockBuscarPlanValidaciones.Object, validaciones, mockPlanesCotizadosCalcularPrima.Object);

            var planes = new List<Plan>
            {
                new Plan
                {
                    Nombre = "Basico",
                    Descripcion = "Plan que cubre todas las coberturas"
                },
                new Plan
                {
                    Nombre = "Medio",
                    Descripcion = "Plan con cobertura media"
                },
                new Plan
                {
                    Nombre = "Full",
                    Descripcion = "Plan con cobertura full"
                }
            };

            var planesDto = new List<PlanCotizadoDto>
            {
                new PlanCotizadoDto
                {
                    Nombre = "Basico",
                    Descripcion = "Plan que cubre todas las coberturas"
                },
                new PlanCotizadoDto
                {
                    Nombre = "Medio",
                    Descripcion = "Plan con cobertura media"
                },
                new PlanCotizadoDto
                {
                    Nombre = "Full",
                    Descripcion = "Plan con cobertura full"
                }
            };

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
            var validaciones = new PlanesCotizadosValidaciones();
            var service = new PlanService(mockQuery.Object, mockMapper.Object, mockBuscarPlanValidaciones.Object, validaciones, mockPlanesCotizadosCalcularPrima.Object);

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

    }
}
