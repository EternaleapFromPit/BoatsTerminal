using BoatsTerminal.Boats;
using BoatsTerminal.Infrastructure;
using BoatsTerminal.Price;
using BoatsTerminal.Vehicles;

namespace BoatsTerminal
{
    public class Terminal
    {
        private readonly ILogger _logger;
        private readonly IPriceCalculator _priceCalculator;
        private IList<IBoat> _boats;
        private IList<IVehicle> _vehicles;

        public Terminal(IPriceCalculator priceCalculator, ILogger logger, IList<IBoat> boats)
        {
            _logger = logger;
            _priceCalculator = priceCalculator;
            _vehicles = new List<IVehicle>();
            _boats = boats != null ? boats : new List<IBoat>();
        }

        public void AddBoat(IBoat boat) 
        {
            _boats.Add(boat);
        }

        public void LoadVehicle(IVehicle vehicle)
        {
            var boat = GetBoatForLoading(vehicle);

            if (boat == null)
                throw new InvalidOperationException("No free boats to load your Vehicle");

            _logger.Log($"Loading {vehicle.Name} onto {boat.GetType()}");

            boat.Load(vehicle);
            _vehicles.Add(vehicle);
            _logger.Log($"Loaded {vehicle.Name} onto {boat.GetType()}; boat capacity is {boat.CurrentCapacity}");
        }

        public decimal GetPrice() => _priceCalculator.GetTotalPrice(_vehicles);
                

        private IBoat GetBoatForLoading(IVehicle vehicle) =>
            _boats.SingleOrDefault(x => x.CurrentCapacity != 0 && x.MinVehicleWeigth <= vehicle.Weight && vehicle.Weight <= x.MaxVehicleWeigth);

    }
}
