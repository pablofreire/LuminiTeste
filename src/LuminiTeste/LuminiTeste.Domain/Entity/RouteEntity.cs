namespace LuminiTeste.Domain.Entity
{
    public class RouteEntity
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int Cost { get; set; }

        public RouteEntity() { }

        public RouteEntity(string origin, string destination, int cost)
        {
            Origin = origin;
            Destination = destination;
            Cost = cost;
        }
    }
}
