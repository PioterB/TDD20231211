namespace VehiclesDiary.Logic.Events
{
    public class VehicleEvent
    {
        public VehicleEvent(int mileage)
        {
            Mileage = mileage;
        }

        /// <summary>
        /// Get mileage when event was registed.
        /// </summary>
        public int Mileage { get; }
    }
}