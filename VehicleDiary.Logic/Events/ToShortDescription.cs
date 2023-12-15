namespace VehiclesDiary.Logic.Events
{
    public class ToShortDescription : IValidationRule<VehicleEventRequest>
    {
        public bool NotBroken(VehicleEventRequest input)
        {
            return input.Description.Length > 5;
        }
    }
}