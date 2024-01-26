using BusTerminalProject.Models;

namespace BusTerminalProject.Entities
{
    public class TicketModel
    {
        public TicketModel()
        {

        }
        public TicketModel(string firstName, string lastName, TripModel trip)
        {
            PassangerFirstName = firstName;
            PassengerLastName = lastName;
            Trip = trip;
            TripId = trip.Id;
        }
        public int Id { get; set; }
        public string PassangerFirstName { get; set; }
        public string PassengerLastName { get; set; }
        public int TripId { get; set; }
        public TripModel Trip { get; set; }
        public int SeatNumber { get; set; }
        public SeatStatus SeatStatus { get; set; }
    }
}
