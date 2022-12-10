using BoatsTerminal.Vehicles;

namespace BoatsTerminal.Price
{
    internal class VehicleTypePriceProvider : IPriceProvider
    {
        private readonly Dictionary<string, decimal> _prices = new Dictionary<string, decimal>
        {
            { "Car", 300 },
            { "MiniBus", 400 },
            { "Bus", 500 },
            { "Truck", 750 }
        };


        public decimal GetPrice(IVehicle vehicle)
        {
            return _prices[vehicle.Name];
        }
    }
}
