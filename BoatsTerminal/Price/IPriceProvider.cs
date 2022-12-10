using BoatsTerminal.Vehicles;


namespace BoatsTerminal.Price
{
    public interface IPriceProvider
    {
        public decimal GetPrice(IVehicle vehicle);
    }
}
