using System.Collections.Generic;

namespace VehicleDiary.Logic
{
    public class VehicleService : IVehiclesService
    {
        private HashSet<Vehicle> _memory = new HashSet<Vehicle>(); 

        public bool Add(Car newItem)
        {
            return _memory.Add(newItem);    
        }
    }
}