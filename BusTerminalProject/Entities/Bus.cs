
namespace BusTerminalProject.Entities
{
    public class Bus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BusType BusType { get; set; }
        public List<Trip>? Trips { get; set; }
        public int SeatCount { get; set; }
    }
}
