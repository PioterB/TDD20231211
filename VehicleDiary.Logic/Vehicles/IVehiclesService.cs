using VehiclesDiary.Logic.Events;
using VehiclesDiary.Tools;

namespace VehiclesDiary.Logic.Vehicles
{
    public interface IVehiclesService
    {
        bool Add(Vehicle newItem);

        Result<Vehicle> Add(VehicleCreationRequest input);

        bool Delete(string name);

        Result<VehicleEvent> NewEvent(VehicleEventRequest input);
    }
}