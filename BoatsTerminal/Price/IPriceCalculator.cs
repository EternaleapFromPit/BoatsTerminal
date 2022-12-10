using BoatsTerminal.Vehicles;

namespace BoatsTerminal.Price
{
    public interface IPriceCalculator
    {
        public decimal GetTotalPrice(IList<IVehicle> vehicles);
    }
}
