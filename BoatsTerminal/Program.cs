// See https://aka.ms/new-console-template for more information
using BoatsTerminal;
using BoatsTerminal.Boats;
using BoatsTerminal.Infrastructure;
using BoatsTerminal.Price;
using BoatsTerminal.Vehicles;

var priceCalculator = new PriceCalculator(new VehicleTypePriceProvider());

var terminal = new Terminal(priceCalculator, new Logger(), new List<IBoat> { new SmallBoat(), new BigBoat() });

terminal.LoadVehicle(new Bus());
terminal.LoadVehicle(new Car());
terminal.LoadVehicle(new Car());

Console.WriteLine($"Current price is {terminal.GetPrice()}");

terminal.LoadVehicle(new Truck());

Console.WriteLine($"Current price is {terminal.GetPrice()}");

Console.ReadKey();