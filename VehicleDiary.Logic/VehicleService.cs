using System.Collections.Generic;
using System.Linq;
using VehiclesDiary.Logic;
using VehiclesDiary.Tools;
using VehiclesDiary.Tools.Persistence;

namespace VehicleDiary.Logic
{
    /// <summary>
    /// Manipuluje zbiorem
    /// </summary>
    public class VehicleService : IVehiclesService
    {
        private readonly IRepository<string, Vehicle> _vehiclesRepository;

        public VehicleService(IRepository<string, Vehicle> vehiclesRepository)
        {
            _vehiclesRepository = vehiclesRepository;
        }

        public bool Add(Vehicle newItem)
        {
            var has = _vehiclesRepository.Exists(newItem.Name);
            if (has) { return false; }

           _vehiclesRepository.Add(newItem.Name, newItem);
            return true;
        }

        public Result<Vehicle> Add(VehicleCreationRequest input)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(string name)
        {
            _vehiclesRepository.Remove(name);
            return true;
        }
    }
}