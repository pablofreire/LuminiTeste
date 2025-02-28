using System.Collections.Generic;
using System.Linq;
using LuminiTeste.Application.Service;
using LuminiTeste.Domain.Dto;
using LuminiTeste.Domain.Entity;
using LuminiTeste.Domain.Interface.Repository;
using NSubstitute;
using Xunit;

namespace LuminiTeste.Tests.Service
{
    public class RouteServiceTests
    {
        private readonly IRouteRepository _repository;
        private readonly RouteService _service;

        public RouteServiceTests()
        {
            _repository = Substitute.For<IRouteRepository>();
            _service = new RouteService(_repository);
        }

        [Fact]
        public void AddRoute_ShouldReturnSuccess_WhenRouteIsAdded()
        {
            // Arrange
            var routeDto = new RouteDto("GRU", "BRC", 10);
            _repository.GetRouteByOriginAndDestination(routeDto.Origin, routeDto.Destination).Returns((RouteEntity)null);

            // Act
            var result = _service.AddRoute(routeDto.Origin, routeDto.Destination, routeDto.Cost);

            // Assert
            Assert.Equal("Rota adicionada com sucesso!", result);
            _repository.Received(1).AddRoute(Arg.Is<RouteEntity>(r => r.Origin == "GRU" && r.Destination == "BRC" && r.Cost == 10));
        }

        [Fact]
        public void FindCheapestRoute_ShouldReturnCheapestRoute_WhenRoutesExist()
        {
            // Arrange
            var routes = new List<RouteEntity>
            {
                new RouteEntity("GRU", "BRC", 10),
                new RouteEntity("BRC", "SCL", 5),
                new RouteEntity("GRU", "SCL", 20)
            };
            _repository.GetAllRoutes().Returns(routes);

            // Act
            var result = _service.FindCheapestRoute("GRU", "SCL");

            // Assert
            Assert.Equal("GRU - BRC - SCL ao custo de $15", result);
        }
    }
} 