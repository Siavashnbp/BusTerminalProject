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
        private static readonly DbRepository<Ticket> _ticketRepository;
        static TerminalOperator()
        {
            _busRepository = DbRepository<Bus>.GetInstance();
            _locationRepository = DbRepository<Location>.GetInstance();
            _tripRepository = DbRepository<Trip>.GetInstance();
            _ticketRepository = DbRepository<Ticket>.GetInstance();
        }
        public static void AddBus(string name, BusType busType)
        {
            var bus = new Bus()
            {
                Name = name,
                BusType = busType,
                SeatCount = busType == BusType.Normal ? 44 : 30
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
                if (bus.BusType == BusType.Normal)
                {
                    busModels.Add(new BusModel(bus.Name!)
                    {
                        Id = bus.Id,
                    });
                }
                else
                {
                    busModels.Add(new BusVipModel(bus.Name!)
                    {
                        Id = bus.Id
                    });
                }
            }
            return busModels;
        }
        public static List<LocationModel> GetLocations()
        {
            var locations = _locationRepository.GetAll();
            var locationModels = new List<LocationModel>();
            foreach (var location in locations)
            {
                locationModels.Add(new LocationModel(location.Province, location.City, location.Name)
                {
                    Id = location.Id,
                });
            }
            return locationModels;
        }
        public static List<TripModel> GetTrips()
        {
            var trips = _tripRepository.GetAll();
            var tripsModels = new List<TripModel>();
            foreach (var trip in trips)
            {
                tripsModels.Add(
                    new TripModel(FindLocationById(trip.OriginId)
                    , FindLocationById(trip.DestinationId)
                    , FindBusById(trip.BusId))
                    {
                        Id = trip.Id,
                        SeatPrice = trip.SeatPrice,
                    });
            }
            return tripsModels;
        }
        public static LocationModel FindLocationById(int id)
        {
            var location = _locationRepository.FindById(id);
            if (location is not null)
            {
                return new LocationModel(location.Province, location.City, location.Name);
            }
            throw new Exception("Location was not found");
        }
        public static BusModel FindBusById(int id)
        {
            var bus = _busRepository.FindById(id);
            if (bus is not null)
            {
                if (bus.BusType == BusType.Vip)
                {
                    return new BusVipModel(bus.Name!);
                }
                else
                {
                    return new BusModel(bus.Name!);
                }
            }
            throw new Exception("Bus was not found");
        }
        public static List<Ticket> GetBusReservedSeats(int tripId)
        {
            var db = new BusTerminalDbContext();
            var reservedSeats = db.Tickets
                .Where(_ => _.TripId == tripId && _.SeatStatus == SeatStatus.Reserved).ToList();
            return reservedSeats;
        }
        public static List<Ticket> GetBusPurchasedSeats(int tripId)
        {
            var db = new BusTerminalDbContext();
            var purchasedSeats = db.Tickets
                .Where(_ => _.TripId == tripId && _.SeatStatus == SeatStatus.Purchased).ToList();
            return purchasedSeats;
        }
        public static List<Ticket> GetBusCancelledSeats(int tripId)
        {
            var db = new BusTerminalDbContext();
            var cancelledSeats = db.Tickets
                .Where(_ => _.TripId == tripId && _.SeatStatus < 0).ToList();
            return cancelledSeats;
        }
        public static List<Ticket> GetTripBusSeats(int tripId)
        {
            var db = new BusTerminalDbContext();
            var tickets = db.Tickets
                .Where(_ => _.TripId == tripId).ToList();
            return tickets;
        }
        public static void ViewBusTypes()
        {
            var busTypesValues = (int[])Enum.GetValues(typeof(BusType));
            var busTypeNames = Enum.GetNames(typeof(BusType));
            for (int i = 0; i < busTypesValues.Length; i++)
            {
                Console.WriteLine($"{busTypesValues[i]} - {busTypeNames[i]}");
            }
        }
        public static BusType GetBusType(int value)
        {
            if (Enum.IsDefined(typeof(BusType), (int)value))
            {
                return (BusType)value;
            }
            throw new Exception("Bus type is not defined");
        }
        public static TripModel FindTripbyId(int id)
        {
            var trip = _tripRepository.FindById(id);
            if (trip is not null)
            {
                var origin = FindLocationById(trip.OriginId);
                var destination = FindLocationById(trip.DestinationId);
                var bus = FindBusById(trip.BusId);
                var tripModel = new TripModel(origin, destination, bus)
                {
                    Id = id,
                    PurchaseCancelation = trip.PurchaseCancelation,
                    ReserveCancelation = trip.ReserveCancelation,
                };
                tripModel.SeatPrice = trip.SeatPrice;
                return tripModel;
            }
            throw new Exception("Trip was not found");
        }
        public static void ReserveTicket(TripModel trip, string passengerFirstName, string passengerLastName, int seatNumber)
        {
            var ticket = new Ticket
            {
                PassangerFirstName = passengerFirstName,
                PassengerLastName = passengerLastName,
                TripId = trip.Id,
                SeatStatus = SeatStatus.Reserved,
                SeatNumber = seatNumber,
                PaidPrice = trip.SeatPrice * 0.3M
            };
            _ticketRepository.Add(ticket);
        }
        public static void PurchaseTicket(TripModel trip, string passengerFirstName, string passengerLastName, int seatNumber)
        {
            var ticket = new Ticket
            {
                PassangerFirstName = passengerFirstName,
                PassengerLastName = passengerLastName,
                TripId = trip.Id,
                SeatStatus = SeatStatus.Purchased,
                SeatNumber = seatNumber,
                PaidPrice = trip.SeatPrice,
            };
            _ticketRepository.Add(ticket);
        }
        public static bool CheckSeatIsfree(int tripId, int seatNumber)
        {
            var db = new BusTerminalDbContext();
            var isPurchasedOrReserved = db.Set<Ticket>().Any(_ => _.SeatNumber == seatNumber
            && (_.SeatStatus == SeatStatus.Reserved || _.SeatStatus == SeatStatus.Purchased));
            return !isPurchasedOrReserved;
        }
        public static decimal CancleTicket(int ticketId)
        {
            var db = new BusTerminalDbContext();
            var ticket = _ticketRepository.FindById(ticketId);
            if (ticket is null)
            {
                throw new Exception("Ticket was not found");
            }
            var trip = _tripRepository.FindById(ticket.TripId);
            if (trip is null)
            {
                throw new Exception("Trip was not found");
            }
            decimal returnPrice;
            if (ticket.SeatStatus == SeatStatus.Purchased)
            {
                trip.PurchaseCancelation++;
                returnPrice = trip.SeatPrice * 0.1M;
            }
            else
            {
                trip.ReserveCancelation++;
                returnPrice = trip.SeatPrice * 0.2M;
            }
            ticket.SeatStatus = (SeatStatus)((int)ticket.SeatStatus * (-1));
            db.Set<Trip>().Update(trip);
            db.Set<Ticket>().Update(ticket);
            var changes = db.SaveChanges();
            if (changes < 1)
            {
                throw new Exception("Changes were not saved");
            }
            return returnPrice;
        }
        public static List<TicketModel> GetAllTickets()
        {
            return _ticketRepository.GetAll()
                .Select(_ => new TicketModel(_.PassangerFirstName, _.PassengerLastName, FindTripbyId(_.TripId))
                {
                    Id = _.Id,
                    SeatNumber = _.SeatNumber,
                    SeatStatus = _.SeatStatus,
                }).ToList();
        }
    }
}
