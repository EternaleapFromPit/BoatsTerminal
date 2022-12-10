using BoatsTerminal.Vehicles;

namespace BoatsTerminal.Price
{
    public class PriceCalculator : IPriceCalculator
    {
        private readonly IPriceProvider _priceProvider;

        public PriceCalculator(IPriceProvider priceProvider) 
        {
            _priceProvider = priceProvider;
        }

        public decimal GetTotalPrice(IList<IVehicle> vehicles) => vehicles.Sum(v => _priceProvider.GetPrice(v));
    }
}
