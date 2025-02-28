using LuminiTeste.Domain.Dto;

namespace LuminiTeste.Domain.Interface.Service
{
    public interface IRouteService
    {
        string FindCheapestRoute(string origin, string destination);
        string AddRoute(string origin, string destination, int cost);
    }
}
