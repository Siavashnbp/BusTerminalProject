using BusTerminalProject.Models;

namespace BusTerminalProject.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string PassangerFirstName { get; set; }
        public string PassengerLastName { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        public int SeatNumber { get; set; }
        public SeatStatus SeatStatus { get; set; }
    }
}
