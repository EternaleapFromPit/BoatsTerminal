using BoatsTerminal.Vehicles;

namespace BoatsTerminal.Boats
{
    class BigBoat : IBoat
    {
        int _currentCapacity = 5;

        public double MinVehicleWeigth => 3.5;

        public double MaxVehicleWeigth => 7.5;

        public int CurrentCapacity => _currentCapacity;        

        public void Load(IVehicle vehicle)
        {
            if(_currentCapacity != 0)
                _currentCapacity--;
        }
    }
}
