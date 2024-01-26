using BusTerminalProject.Db;
using BusTerminalProject.Entities;
using BusTerminalProject.Models;
namespace BusTerminalProject
{
    public static class TerminalOperator
    {
        private static readonly DbRepository<Bus> _busRepository;
        private static readonly DbRepository<Location> _locationRepository;
        private static readonly DbRepository<Trip> _tripRepository;
        static TerminalOperator()
        {
            _busRepository = DbRepository<Bus>.GetInstance();
            _locationRepository = DbRepository<Location>.GetInstance();
            _tripRepository = DbRepository<Trip>.GetInstance();
        }
        public static void AddBus(string name, BusType busType)
        {
            var bus = new Bus()
            {
                Name = name,
                BusType = busType,
                SeatCount = busType == BusType.Normal ? 40 : 30
            };
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
            var location = new Location()
            {
                Province = province,
                City = city,
                Name = name
            };
            _locationRepository.Add(location);
        }
        public static void AddTrip(int originId, int destinationId, int busId, decimal price)
        {
            var trip = new Trip
            {
                BusId = busId,
                OriginId = originId,
                DestinationId = destinationId,
                SeatPrice = price,
                PurchaseCancelation = 0,
                ReserveCancelation = 0,
            };
            _tripRepository.Add(trip);
        }
        public static List<BusModel> GetBusses()
        {
            var busses = _busRepository.GetAll();
            var busModels = new List<BusModel>();
            foreach (var bus in busses)
            {
                busModels.Add(new BusModel(bus.Name, bus.BusType));
            }
            return busModels;
        }
        public static List<LocationModel> GetLocations()
        {
            var locations = _locationRepository.GetAll();
            var locationModels = new List<LocationModel>();
            foreach (var location in locations)
            {
                locationModels.Add(new LocationModel(location.Province, location.City, location.Name));
            }
            return locationModels;
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
