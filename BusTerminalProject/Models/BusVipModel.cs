using BusTerminalProject.Entities;

namespace BusTerminalProject.Models
{
    public class BusVipModel : BusModel
    {
        public BusVipModel(string name) : base(name)
        {

        }
        public override void ShowSeats()
        {
            foreach (var seat in BusSeats)
            {
                Console.Write($"{seat.SeatNumber:D2}");
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
