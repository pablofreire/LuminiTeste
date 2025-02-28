using System.Data;
using LuminiTeste.Domain.Entity;
using LuminiTeste.Domain.Interface.Repository;
using LuminiTeste.Domain.Interface.Service;

namespace LuminiTeste.Application.Service
{
    public class RouteService : IRouteService
    {
        private readonly IRouteRepository _repository;

        public RouteService(IRouteRepository repository)
        {
            _repository = repository;
        }

        public string AddRoute(string origin, string destination, int cost)
        {
            var existingRoute = _repository.GetRouteByOriginAndDestination(origin, destination);
            if (existingRoute != null)
            {
                return "Rota já cadastrada.";
            }

            var route = new RouteEntity(origin, destination, cost);
            _repository.AddRoute(route);
            return "Rota adicionada com sucesso!";
        }

        public string FindCheapestRoute(string origin, string destination)
        {
            var allRoutes = _repository.GetAllRoutes();

            if (!allRoutes.Any(r => r.Origin == origin))
            {
                return "Origem não cadastrada.";
            }

            if (!allRoutes.Any(r => r.Destination == destination))
            {
                return "Destino não cadastrado.";
            }

            var paths = new List<(List<string> Path, int TotalCost)>();

            void Explore(string current, List<string> path, int cost)
            {
                path.Add(current);

                if (current == destination)
                {
                    paths.Add((new List<string>(path), cost));
                }
                else
                {
                    foreach (var route in allRoutes.Where(r => r.Origin == current && !path.Contains(r.Destination)))
                    {
                        Explore(route.Destination, path, cost + route.Cost);
                    }
                }

                path.Remove(current);
            }

            Explore(origin, new List<string>(), 0);

            var cheapest = paths.OrderBy(p => p.TotalCost).FirstOrDefault();
            return cheapest.Path != null
                ? $"{string.Join(" - ", cheapest.Path)} ao custo de ${cheapest.TotalCost}"
                : "Rota não encontrada.";
        }
    }
}
