using VehicleDiary.Logic;

namespace VehiclesDiary.Tests
{
    internal class VehicleFactory
    {
        public static Vehicle Create(string name = null, string make = null)
        {
            name = name ?? "default name";
            make = make ?? "default make";

            return new Car(name, make, "model");
        }
    }
}
