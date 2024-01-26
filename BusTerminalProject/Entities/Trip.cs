namespace BusTerminalProject.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public int OriginId { get; set; }
        public Location Origin { get; set; }
        public int DestinationId { get; set; }
        public Location Destination { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; }
        public decimal SeatPrice { get; set; }
        public int ReserveCancelation { get; set; }
        public int PurchaseCancelation { get; set; }
        public List<Ticket>? Tickets { get; set; }
    }
}
