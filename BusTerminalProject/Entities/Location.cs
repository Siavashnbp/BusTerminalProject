namespace BusTerminalProject.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public List<Trip> TripsAsOrigin { get; set; }
        public List<Trip> TripsAsDestination { get; set; }
    }
}
