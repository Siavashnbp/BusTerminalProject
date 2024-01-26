using BusTerminal.Db;
using BusTerminal.EnitityMap;
using BusTerminal.Entities;
namespace BusTerminal
{
    public static class TerminalOperator
    {
        private static readonly DbRepository<Bus> _busRepository;
        private static readonly DbRepository<BusSeat> _busSeatRepository;
        static TerminalOperator()
        {
            _busRepository = DbRepository<Bus>.GetInstance();
        }
        public static void AddBus(string name, BusType busType)
        {
            var bus = new Bus(name, busType);
            _busRepository.Add(bus);
        }
        public static List<Bus> GetBusses()
        {
            return _busRepository.GetAll();
        }
        public static void GetBusSeats(Bus bus)
        {
            var db = new BusTerminalDbContext();
            var seats = db.BusSeats.Where(_ => _.BusId == bus.Id).ToList();
            bus.BusSeats = seats;
        }
    }
}
