using VehiclesDiary.Logic.Vehicles;
using VehiclesDiary.Tools.Persistence;

namespace VehiclesDiary.Logic.Events
{
    public class MaliciuseMileage : IValidationRule<VehicleEventRequest>
    {
        private readonly IRepository<string, Vehicle> _vehiclesRepository;

        public MaliciuseMileage(IRepository<string, Vehicle> vehiclesRepository)
        {
            _vehiclesRepository = vehiclesRepository;
        }

        public bool NotBroken(VehicleEventRequest input)
        {
            return input.Mileage < _vehiclesRepository.Get(input.Vehicle).LastEvent.Mileage;
        }
    }
}