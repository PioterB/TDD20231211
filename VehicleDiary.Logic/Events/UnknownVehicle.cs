using VehiclesDiary.Logic.Vehicles;
using VehiclesDiary.Tools.Persistence;

namespace VehiclesDiary.Logic.Events
{
    public class UnknownVehicle : IValidationRule<VehicleEventRequest>
    {
        private readonly IRepository<string, Vehicle> _vehiclesRepository;

        public UnknownVehicle(IRepository<string, Vehicle> vehiclesRepository)
        {
            _vehiclesRepository = vehiclesRepository;
        }

        public bool NotBroken(VehicleEventRequest input)
        {
            return _vehiclesRepository.Exists(input.Vehicle);
        }
    }
}