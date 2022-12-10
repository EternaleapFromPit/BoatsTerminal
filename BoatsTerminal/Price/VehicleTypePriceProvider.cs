using BoatsTerminal.Vehicles;

namespace BoatsTerminal.Price
{
    public class VehicleTypePriceProvider : IPriceProvider
    {
        // have to be replaced with the database or file or something
        private readonly Dictionary<string, decimal> _prices = new Dictionary<string, decimal>
        {
            { "Car", 300 },
            { "MiniBus", 400 },
            { "Bus", 500 },
            { "Truck", 750 }
        };


        public decimal GetPrice(IVehicle vehicle)
        {
            if (!_prices.ContainsKey(vehicle.Name))
                throw new KeyNotFoundException($"There is no price for {vehicle.Name} in database");

            return _prices[vehicle.Name];
        }
    }
}
