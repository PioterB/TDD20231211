using VehiclesDiary.Logic;
using VehiclesDiary.Logic.Events;
using VehiclesDiary.Logic.Vehicles;

namespace VehiclesDiary.Tests
{
    internal class VehicleFactory
    {
        public static Vehicle Create(string name = null, string make = null, VehicleEvent lastEvent = null)
        {
            name = name ?? "default name";
            make = make ?? "default make";
            lastEvent = lastEvent ?? VehicleEventFactory.Create();

            return new Car(name, make, "model", lastEvent);
        }
    }
}
