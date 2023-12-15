using System;

namespace VehiclesDiary.Logic.Events
{
    public class VehicleEventRequest
    {
        /// <summary>
        /// Gets value which identifies <see cref="Vehicle"/>.
        /// </summary>
        public string Vehicle { get; set; }
        public DateTime? Created { get; internal set; }
        public string Description { get; internal set; }
        public int? Mileage { get; internal set; }
    }
}