using BusTerminalProject.Models;

namespace BusTerminalProject.Entities
{
    public class TicketModel
    {
        public TicketModel(string firstName, string lastName, TripModel trip)
        {
            PassangerFirstName = firstName;
            PassengerLastName = lastName;
            Trip = trip;
        }
        public int Id { get; set; }
        public string PassangerFirstName { get; set; }
        public string PassengerLastName { get; set; }
        public TripModel Trip { get; set; }
        public int SeatNumber { get; set; }
        public SeatStatus SeatStatus { get; set; }
    }
}
