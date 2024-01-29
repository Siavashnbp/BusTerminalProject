using BusTerminalProject.Entities;

namespace BusTerminalProject.Models
{
    public class BusVipModel : BusModel
    {
        public BusVipModel(string name) : base(name)
        {

        }
        public override void FillSeats(List<TicketModel>? tickets)
        {
            BusSeats = new List<BusSeatModel>();
            for (int i = 1; i <= 30; i++)
            {
                var ticket = tickets?.SingleOrDefault(_ => _.SeatNumber == i);
                BusSeats.Add(new BusSeatModel(i)
                {
                    SeatStatus = ticket is null ? SeatStatus.Free : ticket.SeatStatus
                });
            }
        }
        public override void ShowSeats()
        {
            foreach (var seat in BusSeats)
            {
                Console.Write($"{(seat.SeatStatus == SeatStatus.Free ? seat.SeatNumber
                    : seat.SeatStatus == SeatStatus.Reserved ? "rr" : "bb"):D2}");
                if (seat.SeatNumber % 3 == 0 || seat.SeatNumber == 16 || seat.SeatNumber == 17)
                {
                    Console.WriteLine();
                }
                else if (seat.SeatNumber % 3 == 1)
                {
                    Console.Write("\t");
                }
                else
                {
                    Console.Write(" ");
                }
            }
        }
    }
}
