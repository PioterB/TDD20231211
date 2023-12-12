using VehiclesDiary.Logic;
using VehiclesDiary.Tools;

namespace VehicleDiary.Logic
{
    public interface IVehiclesService
    {
        bool Add(Vehicle newItem);

        Result<Vehicle> Add(VehicleCreationRequest input);

        bool Delete(string name);
    }
}