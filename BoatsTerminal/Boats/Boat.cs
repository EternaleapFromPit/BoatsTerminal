using BoatsTerminal.Vehicles;

namespace BoatsTerminal.Boats
{
    public abstract class Boat : IBoat
    {
        protected int _currentCapacity;
        
        public Boat(int capacity)
        {
            _currentCapacity = capacity;    
        }

        public int CurrentCapacity => _currentCapacity;

        public abstract double MinVehicleWeigth { get; }
        public abstract double MaxVehicleWeigth { get; }

        public void Load(IVehicle vehicle)
        {
            if (_currentCapacity != 0)
                _currentCapacity--;
        }
    }
}
