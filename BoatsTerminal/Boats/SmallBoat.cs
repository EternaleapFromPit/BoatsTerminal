namespace BoatsTerminal.Boats
{
    public class SmallBoat : Boat
    {
        public SmallBoat() : base(9)
        {
        }

        public override double MinVehicleWeigth => 0;

        public override double MaxVehicleWeigth => 3.5;
    }
}
