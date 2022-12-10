using BoatsTerminal.Vehicles;

namespace BoatsTerminal.Boats
{
    public class SmallBoat : IBoat
    {
        int _currentCapacity = 9;

        public double MinVehicleWeigth => 0;

        public double MaxVehicleWeigth => 3.5;

        public int CurrentCapacity => _currentCapacity;

        public void Load(IVehicle vehicle)
        {
            if (_currentCapacity != 0)
                _currentCapacity--;
        }
    }
}
