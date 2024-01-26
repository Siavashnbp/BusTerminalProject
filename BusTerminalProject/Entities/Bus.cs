namespace BusTerminalProject.Entities
{
    public class Bus
    {
        public Bus()
        {

        }
        public Bus(string name, BusType busType)
        {
            Name = name;
            BusType = busType;
            var seatCount = busType == BusType.VIP ? 30 : 44;
            BusSeats = new List<BusSeat>();
            for (int seatNumber = 1; seatNumber <= seatCount; seatNumber++)
            {
                BusSeats.Add(new(seatNumber));
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BusSeat> BusSeats { get; set; }
        public BusType BusType { get; set; }
        public List<Trip>? Trips { get; set; }
        public static void ViewBusTypes()
        {
            var busTypesNames = Enum.GetNames(typeof(BusType));
            var busTypesValues = (int[])Enum.GetValues(typeof(BusType));
            for (int i = 0; i < busTypesNames.Length; i++)
            {
                Console.WriteLine($"{busTypesValues[i]} - {busTypesNames[i]}");
            }
        }
        public static BusType GetBusType(int value)
        {
            if (Enum.IsDefined(typeof(BusType), value))
            {
                return (BusType)value;
            }
            throw new Exception("type is not defined");
        }
        public void ShowSeats()
        {
            if (BusType == BusType.Normal)
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
            else if (BusType == BusType.VIP)
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
    public enum BusType
    {
        Normal,
        VIP
    }
}
