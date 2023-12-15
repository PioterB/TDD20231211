using VehiclesDiary.Logic.Events;
using VehiclesDiary.Tools;
using VehiclesDiary.Tools.Persistence;

namespace VehiclesDiary.Logic.Vehicles
{
    /// <summary>
    /// Manipuluje zbiorem
    /// </summary>
    public class VehicleService : IVehiclesService
    {
        private readonly IRepository<string, Vehicle> _vehiclesRepository;
        private IValidator<VehicleEventRequest> _eventRequestValidator;

        public VehicleService(IRepository<string, Vehicle> vehiclesRepository, IValidator<VehicleEventRequest> eventRequestValidator)
        {
            _vehiclesRepository = vehiclesRepository;
            _eventRequestValidator = eventRequestValidator;
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

        public Result<VehicleEvent> NewEvent(VehicleEventRequest input)
        {
            var isValid = _eventRequestValidator.Validate(input);
            if (!isValid)
            {
                return Result<VehicleEvent>.Failure();
            }

            var newEvent = new VehicleEvent(input.Mileage.Value);
            return newEvent;
        }
    }
}