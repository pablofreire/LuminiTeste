using Dapper;
using LuminiTeste.Domain.Entity;
using LuminiTeste.Domain.Interface.Repository;

namespace LuminiTeste.Infra.Data.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public RouteRepository(DatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }

        public IEnumerable<RouteEntity> GetAllRoutes()
        {
            using var connection = _databaseConfig.GetConnection();
            connection.Open();
            return connection.Query<RouteEntity>("SELECT Id, Origin, Destination, Cost FROM Routes").ToList();
        }

        public RouteEntity GetRouteByOriginAndDestination(string origin, string destination)
        {
            using var connection = _databaseConfig.GetConnection();
            connection.Open();
            return connection.QueryFirstOrDefault<RouteEntity>(
                "SELECT Id, Origin, Destination, Cost FROM Routes WHERE Origin = @Origin AND Destination = @Destination",
                new { Origin = origin, Destination = destination });
        }

        public void AddRoute(RouteEntity route)
        {
            using var connection = _databaseConfig.GetConnection();
            connection.Open();
            connection.Execute(
                "INSERT INTO Routes (Origin, Destination, Cost) VALUES (@Origin, @Destination, @Cost)",
                new { route.Origin, route.Destination, route.Cost });
            connection.Close();
        }
    }
}
