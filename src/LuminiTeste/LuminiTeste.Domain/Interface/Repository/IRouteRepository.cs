using LuminiTeste.Domain.Entity;

namespace LuminiTeste.Domain.Interface.Repository
{
    public interface IRouteRepository
    {
        IEnumerable<RouteEntity> GetAllRoutes();
        RouteEntity GetRouteByOriginAndDestination(string origin, string destination);
        void AddRoute(RouteEntity route);
    }
}
