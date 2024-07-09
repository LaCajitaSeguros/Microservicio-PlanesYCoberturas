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
            var validaciones = new BuscarPlanValidaciones();
            var service = new PlanService(mockQuery.Object, mockMapper.Object, validaciones, mockPlanesCotizadosValidaciones.Object);

            var plan = new Plan
            {
                Nombre = "Full",
                Descripcion = "Plan que cubre todas las coberturas"
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

            //Act
            var result = await service.BuscarPlan(request);

            //Assert
            result.HttpStatusCode.Should().Be(HttpStatusCode.OK);   
            result.Data.As<PlanDto>().Nombre.Should().Be(plan.Nombre);

        }

        [Fact]
        public async Task BuscarPlan_ShouldReturnNotFound_404()
        {
            //Arrange.
            var mockQuery = new Mock<IPlanQuery>();
            var mockMapper = new Mock<IMapper>();
            var mockPlanesCotizadosValidaciones = new Mock<IPlanesCotizadosValidaciones>();
            var validaciones = new BuscarPlanValidaciones();
            var service = new PlanService(mockQuery.Object, mockMapper.Object, validaciones, mockPlanesCotizadosValidaciones.Object);

            var plan = new Plan
            {
                Nombre = "Full",
                Descripcion = "Plan que cubre todas las coberturas"
            };

            var planDto = new PlanDto
            {
                Nombre = plan.Nombre
            };

            mockQuery.Setup(q => q.ObtenerPlanPorId(It.IsAny<int>())).ReturnsAsync((Plan)null);
            mockMapper.Setup(q => q.Map<PlanDto>(plan)).Returns(planDto);

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