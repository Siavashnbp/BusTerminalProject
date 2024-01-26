using BusTerminalProject.Db;
using BusTerminalProject.Entities;
namespace BusTerminalProject
{
    public static class TerminalOperator
    {
        private static readonly DbRepository<Bus> _busRepository;
        private static readonly DbRepository<Location> _locationRepository;
        static TerminalOperator()
        {
            _busRepository = DbRepository<Bus>.GetInstance();
        }
        public static void AddBus(string name, BusType busType)
        {
            var bus = new Bus(name, busType);
            _busRepository.Add(bus);
        }
        public static void AddLocation(string province, string city, string name)
        {
            var db = new BusTerminalDbContext();
            if (db.Locations.Any(_ => _.City == city && _.Province == province
            && _.Name == name))
            {
                throw new Exception("This location already exists");
            }
            var location = new Location(province, city, name);
            _locationRepository.Add(location);
        }
        public static List<Bus> GetBusses()
        {
            return _busRepository.GetAll();
        }
        public static List<Location> GetLocations()
        {
            return _locationRepository.GetAll();
        }
        public static List<Ticket> GetBusReservedSeats(Trip trip)
        {
            var db = new BusTerminalDbContext();
            var reservedSeats = db.Tickets
                .Where(_ => _.TripId == trip.Id && _.SeatStatus == SeatStatus.Reserved).ToList();
            return reservedSeats;
        }
        public static List<Ticket> GetBusPurchasedSeats(Trip trip)
        {
            var db = new BusTerminalDbContext();
            var purchasedSeats = db.Tickets
                .Where(_ => _.TripId == trip.Id && _.SeatStatus == SeatStatus.Purchased).ToList();
            return purchasedSeats;
        }
    }
}
