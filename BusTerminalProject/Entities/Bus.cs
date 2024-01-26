
namespace BusTerminalProject.Entities
{
    public class Bus
    {
        public Bus()
        {

        }
        public Bus(string name, BusType busType)
        {
            Name = name;
            BusType = busType;
            var seatCount = busType == BusType.Vip ? 30 : 44;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public BusType BusType { get; set; }
        public List<Trip>? Trips { get; set; }
        public int SeatCount { get; set; }
    }
}
