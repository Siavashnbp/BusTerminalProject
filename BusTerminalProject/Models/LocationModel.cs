namespace BusTerminalProject.Entities
{
    public class LocationModel
    {
        public LocationModel(string province, string city, string name)
        {
            Province = province;
            City = city;
            Name = name;
        }
        public int Id { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public List<TripModel> TripsAsOrigin { get; set; }
        public List<TripModel> TripsAsDestination { get; set; }
    }
}
