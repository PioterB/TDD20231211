using System;
using VehiclesDiary.Logic.Events;

namespace VehiclesDiary.Tests
{
    internal class VehicleEventFactory
    {
        internal static VehicleEvent Create(int? mileage = null)
        {
            mileage = mileage ?? 1000;

            return new VehicleEvent(mileage.Value);
        }
    }
}