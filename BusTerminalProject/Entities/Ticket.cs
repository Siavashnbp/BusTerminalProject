namespace BusTerminalProject.Entities
{
    public class Ticket
    {
        public Ticket()
        {

        }
        public Ticket(string firstName, string lastName, Trip trip)
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
        public Trip Trip { get; set; }
        public int SeatNumber { get; set; }
        public SeatStatus SeatStatus { get; set; }
    }
}
