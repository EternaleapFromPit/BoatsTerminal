using BoatsTerminal.Boats;
using BoatsTerminal.Price;
using BoatsTerminal.Vehicles;
using BoatsTerminal;
using BoatsTerminal.Infrastructure;
using Moq;
using System.Diagnostics;

namespace BoatsTerminalTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Verify_5_buses_and_9_cars_could_be_loaded()
        {
            var priceCalculator = new PriceCalculator(new VehicleTypePriceProvider());
            var terminal = new Terminal(priceCalculator, new Mock<ILogger>().Object, new List<IBoat> { new SmallBoat(), new BigBoat() });

            terminal.LoadVehicle(new Bus());
            terminal.LoadVehicle(new Bus());
            terminal.LoadVehicle(new Bus());
            terminal.LoadVehicle(new Bus());
            terminal.LoadVehicle(new Bus());

            Assert.Throws<InvalidOperationException>(() => terminal.LoadVehicle(new Bus()));

            for (int i = 0; i < 9; i++)
                terminal.LoadVehicle(new Car());

            Assert.Throws<InvalidOperationException>(() => terminal.LoadVehicle(new Car()));
        }

        [Test]
        public void Verify_overweightet_vehicle_could_not_be_loaded()
        {
            var testBoat = new Mock<IVehicle>();
            testBoat.Setup(t => t.Weight).Returns(4);

            var priceCalculator = new PriceCalculator(new VehicleTypePriceProvider());
            var smallBoatTerminal = new Terminal(priceCalculator, new Mock<ILogger>().Object, new List<IBoat>{ new SmallBoat() });
            var bigBoatTerminal = new Terminal(priceCalculator, new Mock<ILogger>().Object, new List<IBoat> { new BigBoat() });

            Assert.Throws<InvalidOperationException>(() => smallBoatTerminal.LoadVehicle(testBoat.Object));

            testBoat = new Mock<IVehicle>();
            testBoat.Setup(t => t.Weight).Returns(9);

            Assert.Throws<InvalidOperationException>(() => bigBoatTerminal.LoadVehicle(testBoat.Object));
        }

        class TestBoat : Boat
        {
            public TestBoat() : base(9)
            {
            }

            public override double MinVehicleWeigth => 1;

            public override double MaxVehicleWeigth => 9;

        }

        [Test]
        public void Verify_additioal_boat_could_accept_vehicles()
        {
            var priceCalculator = new PriceCalculator(new VehicleTypePriceProvider());
            var terminal = new Terminal(priceCalculator, new Mock<ILogger>().Object, new List<IBoat> { new SmallBoat(), new BigBoat() });

            terminal.LoadVehicle(new Bus());
            terminal.LoadVehicle(new Bus());
            terminal.LoadVehicle(new Bus());
            terminal.LoadVehicle(new Bus());
            terminal.LoadVehicle(new Bus());

            for (int i = 0; i < 9; i++)
                terminal.LoadVehicle(new Car());

            var testBoat = new TestBoat();
            terminal.AddBoat(testBoat);
            Assert.DoesNotThrow(() => terminal.LoadVehicle(new Truck()));
            Assert.DoesNotThrow(() => terminal.LoadVehicle(new MiniBus()));
            Assert.That(testBoat.CurrentCapacity, Is.EqualTo(7));
        }

        [Test]
        public void Verify_price_calc_throws_exception_for_unknown_vehicle()
        {
            var priceCalculator = new PriceCalculator(new VehicleTypePriceProvider());
            var terminal = new Terminal(priceCalculator, new Mock<ILogger>().Object, new List<IBoat> { new SmallBoat(), new BigBoat() });
            var testVehicle = new Mock<IVehicle>();
            testVehicle.Setup(x => x.Weight).Returns(3);
            testVehicle.Setup(x => x.Name).Returns("Test");

            terminal.LoadVehicle(testVehicle.Object);

            Assert.Throws<KeyNotFoundException>(() => terminal.GetPrice());
        }

        [Test]
        public void Verify_total_price_fairly_calculated()
        {
            var priceCalculator = new PriceCalculator(new VehicleTypePriceProvider());
            var terminal = new Terminal(priceCalculator, new Mock<ILogger>().Object, new List<IBoat> { new SmallBoat(), new BigBoat() });

            terminal.LoadVehicle(new Truck());
            terminal.LoadVehicle(new Car());
            terminal.LoadVehicle(new MiniBus());
            terminal.LoadVehicle(new Bus());

            Assert.That(terminal.GetPrice(), Is.EqualTo(1950));
        }
    }
}