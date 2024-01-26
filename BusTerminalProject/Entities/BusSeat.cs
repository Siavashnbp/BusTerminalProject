namespace BusTerminalProject.Entities
{
    public class BusSeat
    {
        public BusSeat(int seatNumber)
        {
            SeatNumber = seatNumber;
            SeatStatus = SeatStatus.Free;
        }
        public int SeatNumber { get; set; }
        public SeatStatus SeatStatus { get; set; }

    }
    public enum SeatStatus
    {
        Free,
        Reserved,
        Purchased
    }
}
