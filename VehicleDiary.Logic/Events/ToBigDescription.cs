namespace VehiclesDiary.Logic.Events
{
    public class ToBigDescription : IValidationRule<VehicleEventRequest>
    {
        public bool NotBroken(VehicleEventRequest input)
        {
            return input.Description.Length > 500;
        }
    }
}