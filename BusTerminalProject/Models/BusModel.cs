using BusTerminalProject.Models;

namespace BusTerminalProject.Entities
{
    public class BusModel
    {
        public BusModel(string name)
        {
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BusSeatModel> BusSeats { get; set; }
        public List<TripModel>? Trips { get; set; }

        public virtual void FillSeats(List<TicketModel>? tickets)
        {
            BusSeats = new List<BusSeatModel>();
            for (int i = 1; i <= 44; i++)
            {
                var ticket = tickets?.SingleOrDefault(_ => _.SeatNumber == i);
                BusSeats.Add(new BusSeatModel(i)
                {
                    SeatStatus = ticket is null ? SeatStatus.Free : ticket.SeatStatus
                });
            }
        }
        public virtual void ShowSeats()
        {
            foreach (var seat in BusSeats)
            {
                Console.Write($"{(seat.SeatStatus == SeatStatus.Free ? seat.SeatNumber
                    : seat.SeatStatus == SeatStatus.Reserved ? "rr" : "bb"):D2}");
                if (seat.SeatNumber % 2 == 1)
                {
                    Console.Write(" ");
                }
                else if (seat.SeatNumber % 4 == 0 || seat.SeatNumber == 22)
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write("\t");
                }
            }
        }
    }
}
