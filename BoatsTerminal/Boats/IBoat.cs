using BoatsTerminal.Vehicles;

namespace BoatsTerminal.Boats
{
    public interface IBoat
    {
        double MinVehicleWeigth { get; }

        double MaxVehicleWeigth { get; }

        int CurrentCapacity { get; }

        public void Load(IVehicle vehicle);

    }
}