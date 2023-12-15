using System;
using VehiclesDiary.Logic.Events;
using VehiclesDiary.Logic.Vehicles;

namespace VehiclesDiary.Tests
{
    class VehicleEventRequestFactory
    {
        internal static VehicleEventRequest Create(string vehicle = null, DateTime? created = null, string description = null, int? mileage = null)
        {
            vehicle = vehicle ?? "known vehicle";
            created = created ?? DateTime.Now.AddHours(-1);
            description = description ?? "something happend";
            mileage = mileage ?? 500000;

            return new VehicleEventRequest()
            {
                Vehicle = vehicle,
                Created = created,
                Description = description,
                Mileage = mileage,
            };
        }

        internal static VehicleEventRequest For(Vehicle owner)
        {
            var lastEvent = owner.LastEvent ?? VehicleEventFactory.Create();
            var mileage = lastEvent.Mileage + 1;
            var created = DateTime.Now.AddHours(-1);
            return Create(vehicle: owner.Name, mileage: mileage, created: created);
        }

        internal static VehicleEventRequest Invalid()
        {
            return new VehicleEventRequest() { Vehicle = ""};
        }

        internal static VehicleEventRequest Nothing()
        {
            return null;
        }
    }
}
