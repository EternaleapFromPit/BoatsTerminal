using BoatsTerminal.Vehicles;

namespace BoatsTerminal.Boats
{
    public class BigBoat : Boat
    {
        public BigBoat() : base(5)
        {
        }

        public override double MinVehicleWeigth => 3.5;

        public override double MaxVehicleWeigth => 7.5;

    }
}
