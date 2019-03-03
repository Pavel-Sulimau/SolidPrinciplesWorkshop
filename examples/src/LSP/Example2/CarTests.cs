using System.Collections.Generic;
using Xunit;

namespace SolidPrinciples.LSP.Example2
{
    public class CarTests
    {
        [Theory, MemberData(nameof(CarsWithFuel))]
        public void StartEngine_HasFuel_EngineIsRunning(Car car)
        {
            car.StartEngine();

            Assert.True(car.IsEngineRunning);
        }

        [Theory, MemberData(nameof(CarsWithoutFuel))]
        public void StartEngine_DoesNotHaveFuel_ShouldThrowOutOfFuelException(Car car)
        {
            Assert.Throws<OutOfFuelException>(() => car.StartEngine());
        }

        [Theory, MemberData(nameof(PaintedCars))]
        public void NewCar_Color_ShouldBePaintedCorrectly(Car car, string expectedColor)
        {
            Assert.Equal(expectedColor, car.Color);
        }

        public static IEnumerable<object[]> CarsWithFuel { get; } = new[]
            {
                new object[] { new Car() },
                // new object[] { new CrimeBossCar(color: "Black", hasFuel: true, hasBomb: true) }, // Throws a new type of exceptions.
                // new object[] { new StolenCar("Blue", true) }, // Precodition strengthened.
                // new object[] { new BrokenCar(color: "Black", hasFuel: true) } // Postconditions weakened.
            };

        public static IEnumerable<object[]> CarsWithoutFuel { get; } = new[]
            {
                new object[] { new Car(hasFuel: false) },
                // new object[] { new BrokenCar(color: "Black", hasFuel: false) }, // Postconditions weakened.
                // new object[] { new CrimeBossCar(color: "Black", hasFuel: false, hasBomb: true) } // Throws a new type of exceptions.
            };

        public static IEnumerable<object[]> PaintedCars { get; } = new[]
            {
                new object[] { new Car("Red", hasFuel: false), "Red" },
                // new object[] { (new ChameleonCar("Orange", hasFuel: false)).SetTemperature(5), "Orange" } // Changing invariants.
            };
    }
}
