namespace BusTerminalProject.Entities
{
    public class BusSeat
    {
        public BusSeat()
        {

        }
        public BusSeat(int id, Bus bus)
        {
            SeatNumber = id;
            SeatStatus = SeatStatus.Free;
            Bus = bus;
            BusId = bus.Id;
        }
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public string? PassangerFullName { get; set; }
        public SeatStatus SeatStatus { get; set; }
        public int BusId { get; set; }
        public Bus Bus { get; set; }
    }
    public enum SeatStatus
    {
        Free,
        Reserved,
        Bought
    }
}
