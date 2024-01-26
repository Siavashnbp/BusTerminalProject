namespace BusTerminalProject.Entities
{
    public class TripModel
    {

        public TripModel(LocationModel origin, LocationModel destination, BusModel bus)
        {
            Origin = origin;
            Destination = destination;
            Bus = bus;
        }

        public int Id { get; set; }
        public LocationModel Origin { get; set; }
        public LocationModel Destination { get; set; }
        public BusModel Bus { get; set; }
        public decimal SeatPrice { get; set; }
        public int ReserveCancelation { get; set; }
        public int PrchaseCancelation { get; set; }
        public List<TicketModel>? Tickets { get; set; }
    }
}
