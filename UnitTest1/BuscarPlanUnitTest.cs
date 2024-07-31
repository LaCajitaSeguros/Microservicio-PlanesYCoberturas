using Aplication;
using Aplication.Dtos.Planes;
using Aplication.Interfaces.Planes;
using Aplication.Interfaces.Planes.BuscarPlan;
using Aplication.Interfaces.Planes.PlanesCotizados;
using Aplication.Requests.Planes;
using Aplication.UseCases.Planes;
using Aplication.UseCases.Planes.BuscarPlan;
using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using Moq;
using System.Net;
using System.Numerics;

namespace UnitTest
{
    public class BuscarPlanUnitTest
    {
        [Fact]
        public async Task BuscarPlan_ShouldReturnSuccess_200()
        {
            //Arrange.
            var mockQuery = new Mock<IPlanQuery>();
            var mockMapper = new Mock<IMapper>();
            var mockPlanesCotizadosValidaciones = new Mock<IPlanesCotizadosValidaciones>();
            var mockPlanesCotizadosCalcularPrima = new Mock<IPlanesCotizadosCalcularPrima>();
            var mockPlanesCotizadosMapper = new Mock<IPlanesCotizadosMapper>();
            var mockBuscarPlanValidaciones = new Mock<IBuscarPlanValidaciones>();
            var service = new PlanService(mockQuery.Object, mockMapper.Object, mockBuscarPlanValidaciones.Object, mockPlanesCotizadosValidaciones.Object, mockPlanesCotizadosCalcularPrima.Object, mockPlanesCotizadosMapper.Object);

            var plan = new Plan
            {
                Nombre = "Full",
            };
            var planDto = new PlanDto
            {
                Nombre = plan.Nombre
            };

            mockQuery.Setup(q => q.ObtenerPlanPorId(It.IsAny<int>())).ReturnsAsync(plan);
            mockMapper.Setup(q => q.Map<PlanDto>(plan)).Returns(planDto);

            var request = new BuscarPlanRequest
            {
                Id = 1
            };

            mockBuscarPlanValidaciones.Setup(q => q.Validaciones(plan, request)).Returns((Error)null);

            //Act
            var result = await service.BuscarPlan(request);

            //Assert
            result.HttpStatusCode.Should().Be(HttpStatusCode.OK);   
        }

        [Fact]
        public async Task BuscarPlan_ShouldReturnNotFound_404()
        {
            //Arrange.
            var mockQuery = new Mock<IPlanQuery>();
            var mockMapper = new Mock<IMapper>();
            var mockPlanesCotizadosValidaciones = new Mock<IPlanesCotizadosValidaciones>();
            var mockPlanesCotizadosCalcularPrima = new Mock<IPlanesCotizadosCalcularPrima>();
            var mockPlanesCotizadosMapper = new Mock<IPlanesCotizadosMapper>();
            var validaciones = new BuscarPlanValidaciones();
            var service = new PlanService(mockQuery.Object, mockMapper.Object, validaciones, mockPlanesCotizadosValidaciones.Object, mockPlanesCotizadosCalcularPrima.Object, mockPlanesCotizadosMapper.Object);

            mockQuery.Setup(q => q.ObtenerPlanPorId(It.IsAny<int>())).ReturnsAsync((Plan)null);
            mockMapper.Setup(q => q.Map<PlanDto>((Plan)null)).Returns((PlanDto)null);

            var request = new BuscarPlanRequest
            {
                Id = 1
            };

            //Act
            var result = await service.BuscarPlan(request);

            //Assert
            var httpStatusCode = result.HttpStatusCode;
            httpStatusCode.Should().Be(HttpStatusCode.NotFound);

        }
    }
}