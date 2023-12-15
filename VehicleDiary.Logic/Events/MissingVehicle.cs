namespace VehiclesDiary.Logic.Events
{
    public class MissingVehicle : IValidationRule<VehicleEventRequest>
    {
        public bool NotBroken(VehicleEventRequest input)
        {
            return string.IsNullOrEmpty(input.Vehicle);
        }
    }
}