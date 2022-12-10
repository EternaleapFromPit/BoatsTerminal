// See https://aka.ms/new-console-template for more information
using BoatsTerminal;
using BoatsTerminal.Boats;
using BoatsTerminal.Infrastructure;
using BoatsTerminal.Price;
using BoatsTerminal.Vehicles;

var priceCalculator = new PriceCalculator(new VehicleTypePriceProvider());

var terminal = new Terminal(priceCalculator, new Logger(), new List<IBoat> { new SmallBoat(), new BigBoat() });

while(true)
{
    Console.WriteLine("Input vehicle first letter to load: c = car, b = bus, t - truck, m = minu bus");

    var key = Console.ReadKey();

    IVehicle vehicle = key.KeyChar switch
    {
        'b' => new Bus(),
        'c' => new Car(),
        't' => new Truck(),
        'm' => new MiniBus(),
        _ => null
    };

    if (vehicle != null)
    {
        terminal.LoadVehicle(vehicle);
        Console.WriteLine($"Current price is {terminal.GetPrice()}");
    }
}