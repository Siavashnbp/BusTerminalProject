using BusTerminalProject.Entities;
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
        "4- Add Location");
    switch (option)
    {
        case "1":
            {
                var busName = GetStringInput("Enter bus' name:");
                Bus.ViewBusTypes();
                var busTypeValue = GetIntegerInput("Select Bust type:");
                var busType = Bus.GetBusType(busTypeValue);
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
                var originIndex = GetIntegerInput("");
                break;
            }
        default:
            break;
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

static void ShowBusses(List<Bus> busses)
{
    int index = 0;
    foreach (var bus in busses)
    {
        Console.WriteLine($"{index++}- {bus.Name}, {bus.BusType}");
    }
}