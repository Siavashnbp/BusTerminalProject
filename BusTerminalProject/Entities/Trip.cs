namespace BusTerminalProject.Entities
{
    public class Trip
    {
        public Trip()
        {

        }
        public Trip(Location origin, Location destination, Bus bus)
        {
            OriginId = origin.Id;
            Origin = origin;
            DestinationId = destination.Id;
            Destination = destination;
            BusId = bus.Id;
            Bus = bus;
        }

        public int Id { get; set; }
        public int OriginId { get; set; }
        public Location Origin { get; set; }
        public int DestinationId { get; set; }
        public Location Destination { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; }
        public DateTime DepartureTime { get; set; }
        public decimal SeatPrice { get; set; }
        public int ReserveCancelation { get; set; }
        public int PrchaseCancelation { get; set; }
        public List<Ticket>? Tickets { get; set; }
    }
}
