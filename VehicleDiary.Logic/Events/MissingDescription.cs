namespace VehiclesDiary.Logic.Events
{
    public class MissingDescription : IValidationRule<VehicleEventRequest>
    {
        public bool NotBroken(VehicleEventRequest input)
        {
            return string.IsNullOrEmpty(input.Description);
        }
    }
}