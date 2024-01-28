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

        public virtual void ShowSeats()
        {

            foreach (var seat in BusSeats)
            {
                Console.Write($"{seat.SeatNumber:D2}");
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
