using System;

namespace VehiclesDiary.Logic.Events
{
    public class IsFutureDate : IValidationRule<VehicleEventRequest>
    {
        public bool NotBroken(VehicleEventRequest input)
        {
            return input.Created < DateTime.Now;
        }
    }
}