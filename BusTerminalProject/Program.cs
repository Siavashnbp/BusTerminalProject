using BusTerminalProject.Entities;
using BusTerminalProject.Models;
using static BusTerminalProject.TerminalOperator;

while (true)
{
    try
    {
        Run();
    }
    catch (Exception exception)
    {
        Console.Clear();
        PrintStarSeprator();
        Console.WriteLine(exception.Message);
        PrintStarSeprator();
    }

}
static void Run()
{
    var option = GetStringInput("1- Add Bus\n" +
        "2- Add Location\n" +
        "3- Add Trip\n" +
        "4- View Trips\n" +
        "5- Reserve Ticket\n" +
        "6- Purchase Ticket\n" +
        "7- Cancle Ticket\n" +
        "8- View Trip Report\n" +
        "0- Exit");
    switch (option)
    {
        case "1":
            {
                var busName = GetStringInput("Enter bus' name:");
                ViewBusTypes();
                var busTypeValue = GetIntegerInput("Select Bust type:");
                var busType = GetBusType(busTypeValue);
                AddBus(busName, busType);
                Console.WriteLine("Bus added Sucessfully");
                break;
            }
        case "2":
            {
                var province = GetStringInput("Enter province:");
                var city = GetStringInput("Enter city:");
                var locationName = GetStringInput("Enter location's name:");
                AddLocation(province, city, locationName);
                break;
            }
        case "3":
            {
                var locations = GetLocations();
                foreach (var location in locations)
                {
                    Console.WriteLine($"{location.Id} - {location.Province} - {location.City} - {location.Name}");
                }
                var originId = GetIntegerInput("Enter origin's Id");
                var destinationId = GetIntegerInput("Enter destination's Id");
                if (originId == destinationId)
                {
                    throw new Exception("Origin and Destination cannot be the same locations");
                }
                var busses = GetBusses();
                foreach (var bus in busses)
                {
                    Console.WriteLine($"{bus.Id} - {bus.Name} - {(bus is BusVipModel ? "Vip" : "Normal")}");
                }
                var busId = GetIntegerInput("Enter bus' Id:");
                var tripPrice = GetDecimalInput("Enter trip's price:");
                AddTrip(originId, destinationId, busId, tripPrice);
                break;
            }
        case "4":
            {
                ViewTrips();
                break;
            }
        case "5":
            {
                ViewTrips();
                var tripId = GetIntegerInput("Enter trip's id:");
                var trip = FindTripbyId(tripId);
                ShowBusSeats(trip);
                var seatNumber = GetIntegerInput("Enter seat number:");
                if (seatNumber < 1 || seatNumber > trip.Bus.BusSeats.Count)
                {
                    throw new Exception("Seat number is out of range");
                }
                var isSeatFree = CheckSeatIsfree(tripId, seatNumber);
                if (!isSeatFree)
                {
                    throw new Exception($"Seat number {seatNumber} is not free");
                }
                var passengerFirstName = GetStringInput("Enter passenger's first name:");
                var passengerLastName = GetStringInput("Enter passenger's last name:");
                Console.WriteLine($"reserve Price: {trip.GetReservePrice()}");
                ReserveTicket(trip, passengerFirstName, passengerLastName, seatNumber);
                Console.WriteLine("Ticket is sucessfully reserved");
                break;
            }
        case "6":
            {
                ViewTrips();
                var tripId = GetIntegerInput("Enter trip's id:");
                var trip = FindTripbyId(tripId);
                ShowBusSeats(trip);
                var seatNumber = GetIntegerInput("Enter seat number:");
                if (seatNumber < 1 || seatNumber > trip.Bus.BusSeats.Count)
                {
                    throw new Exception("Seat number is out of range");
                }
                var isSeatFree = CheckSeatIsfree(tripId, seatNumber);
                if (!isSeatFree)
                {
                    throw new Exception($"Seat number {seatNumber} is not free");
                }
                var passengerFirstName = GetStringInput("Enter passenger's first name:");
                var passengerLastName = GetStringInput("Enter passenger's last name:");
                Console.WriteLine($"reserve Price: {trip.SeatPrice}");
                PurchaseTicket(trip, passengerFirstName, passengerLastName, seatNumber);
                Console.WriteLine("Ticket is sucessfully purchased");
                break;
            }
        case "7":
            {
                var tickets = GetAllTickets().Where(_ => _.SeatStatus >= 0).ToList();
                foreach (var ticket in tickets)
                {
                    Console.WriteLine($"{ticket.Id} - {ticket.PassangerFirstName} {ticket.PassengerLastName} - " +
                        $"Seat Number: {ticket.SeatNumber}" +
                        $" - {ticket.Trip.Origin.ViewData()} to {ticket.Trip.Destination.ViewData()}");
                }
                var ticketId = GetIntegerInput("Enter ticket's id:");
                CancleTicket(ticketId);
                break;
            }
        case "8":
            {
                ViewTrips();
                var tripId = GetIntegerInput("Enter trip's id:");
                var trip = FindTripbyId(tripId);
                trip.Tickets = GetTripTickets(trip);
                trip.FillSeats();
                var income = trip.CalculateTripIncome();
                Console.WriteLine($"Trip Income : {income} - Empty Seats : {trip.Bus.BusSeats.Where(_ => _.SeatStatus == SeatStatus.Free).Count()} " +
                    $"- Reserve Cancellations : {trip.ReserveCancelation} " +
                    $"- Purchase Cancellation : {trip.PurchaseCancelation}");
                trip.Bus.ShowSeats();
                break;
            }
        case "0":
            {
                Environment.Exit(0);
                break;
            }
        default:
            throw new Exception("Invalid Input");
    }
    Console.WriteLine("__________________________");
    Console.WriteLine("Press any Key to Continue");
    Console.ReadKey();
    Console.Clear();
}
void PrintStarSeprator()
{
    Console.WriteLine("***************");
}
static string GetStringInput(string message)
{
    while (true)
    {
        Console.WriteLine(message);
        Console.WriteLine("Type ABORT! to abort operation");
        var input = Console.ReadLine();
        if (input == "ABORT!")
        {
            throw new Exception("Operation was canceled by operator");
        }
        else if (!string.IsNullOrWhiteSpace(input))
        {
            return input;
        }
        throw new Exception("Invalid Input");
    }
}
static decimal GetDecimalInput(string message)
{
    while (true)
    {
        Console.WriteLine(message);
        Console.WriteLine("Type ABORT! to abort operation");
        var input = Console.ReadLine();
        var isValidInput = decimal.TryParse(input, out decimal value);
        if (isValidInput && value >= 0)
        {
            return value;
        }
        else if (input == "ABORT!")
        {
            throw new Exception("Operation was canceled by operator");
        }
        throw new Exception("Invalid input");
    }
}
static int GetIntegerInput(string message)
{
    while (true)
    {
        Console.WriteLine(message);
        Console.WriteLine("Type ABORT! to abort operation");
        var input = Console.ReadLine();
        var isValidInput = int.TryParse(input, out int value);
        if (isValidInput && value >= 0)
        {
            return value;
        }
        else if (input == "ABORT!")
        {
            throw new Exception("Operation was canceled by operator");
        }
        throw new Exception("Invalid input");
    }
}

static void ViewTrips()
{
    var trips = GetTrips();
    foreach (var trip in trips)
    {
        Console.WriteLine($"{trip.Id} - Origin: {trip.Origin.ViewData()} - " +
            $"Destination : {trip.Destination.ViewData()} - Bus: {trip.Bus.Name} " +
            $"{(trip.Bus is BusVipModel ? "Vip" : "Normal")} - Price: {trip.SeatPrice}");
    }
}
static void ShowBusSeats(TripModel trip)
{
    var purchasedTickets = GetBusPurchasedSeats(trip.Id);
    var reservedTickets = GetBusReservedSeats(trip.Id);
    var tickets = purchasedTickets.Concat(reservedTickets);
    trip.Tickets = tickets.Select(_ => new TicketModel(_.PassangerFirstName, _.PassengerLastName, trip)
    {
        PaidPrice = _.PaidPrice,
        SeatNumber = _.SeatNumber,
        SeatStatus = _.SeatStatus,
        Id = _.Id
    }).ToList();
    trip.FillSeats();
    if (trip.Bus is BusModel)
    {
        trip.Bus.ShowSeats();
    }
    else
    {
        var bus = trip.Bus as BusVipModel;
        bus!.ShowSeats();
    }
}
static List<TicketModel>? GetTripTickets(TripModel trip)
{
    var tickets = GetTripBusSeats(trip.Id);
    return tickets.Select(_ => new TicketModel(_.PassangerFirstName, _.PassengerLastName, trip)
    {
        PaidPrice = _.PaidPrice,
        SeatNumber = _.SeatNumber,
        SeatStatus = _.SeatStatus,
        Id = _.Id
    }).ToList();
}