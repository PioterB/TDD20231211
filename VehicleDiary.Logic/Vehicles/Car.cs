using VehiclesDiary.Logic.Events;

namespace VehiclesDiary.Logic.Vehicles
{
    public class Car : Vehicle
    {
        public Car(string name, string make, string model) : base(name, make, model)
        {
        }

        public Car(string name, string make, string model, VehicleEvent lastEvent) : this(name, make, model)
        {
            LastEvent = lastEvent;
        }
    }
}