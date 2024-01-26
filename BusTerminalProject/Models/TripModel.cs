namespace BusTerminalProject.Entities
{
    public class TripModel
    {
        public TripModel()
        {

        }
        public TripModel(LocationModel origin, LocationModel destination, BusModel bus)
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
        public LocationModel Origin { get; set; }
        public int DestinationId { get; set; }
        public LocationModel Destination { get; set; }
        public int BusId { get; set; }
        public BusModel Bus { get; set; }
        public DateTime DepartureTime { get; set; }
        public decimal SeatPrice { get; set; }
        public int ReserveCancelation { get; set; }
        public int PrchaseCancelation { get; set; }
        public List<TicketModel>? Tickets { get; set; }
    }
}
