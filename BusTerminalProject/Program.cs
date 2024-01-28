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
        "7- Cancle Ticket");
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
                    Console.WriteLine($"{bus.Id} - {bus.Name} - {(bus is BusModel ? "Normal" : "Vip")}");
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
                var tickets = GetAllTickets();
                foreach (var ticket in tickets)
                {
                    Console.WriteLine($"{ticket.Id} - {ticket.PassangerFirstName} {ticket.PassengerLastName}" +
                        $" - {ticket.Trip.Origin.ViewData()} to {ticket.Trip.Destination.ViewData()}");
                }
                var ticketId = GetIntegerInput("Enter ticket's id:");
                CancleTicket(ticketId);
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
        var input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            return input;
        }
        Console.WriteLine("Invalid Input");
    }
}
static decimal GetDecimalInput(string message)
{
    while (true)
    {
        Console.WriteLine(message);
        var isValidInput = decimal.TryParse(Console.ReadLine(), out decimal value);
        if (isValidInput && value >= 0)
        {
            return value;
        }
        Console.WriteLine("Invalid input");
    }
}
static int GetIntegerInput(string message)
{
    while (true)
    {
        Console.WriteLine(message);
        var isValidInput = int.TryParse(Console.ReadLine(), out int value);
        if (isValidInput && value >= 0)
        {
            return value;
        }
        Console.WriteLine("Invalid input");
    }
}
static void ShowBusses(List<BusModel> busses)
{
    int index = 0;
    foreach (var bus in busses)
    {
        Console.WriteLine($"{index++}- {bus.Name}, {(bus is BusModel ? "Normal" : "Vip")}");
    }
}

static void ViewTrips()
{
    var trips = GetTrips();
    foreach (var trip in trips)
    {
        Console.WriteLine($"{trip.Id} - Origin: {trip.Origin.ViewData()} - " +
            $"Destination : {trip.Destination.ViewData()} - Bus: {trip.Bus.Name} " +
            $"{(trip.Bus is BusModel ? "Normal" : "Vip")} - Price: {trip.SeatPrice:M2}");
    }
}
static void ShowBusSeats(TripModel trip)
{
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