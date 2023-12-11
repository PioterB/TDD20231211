namespace VehicleDiary.Logic
{
    public interface IVehiclesService
    {
        bool Add(Car newItem);

        bool Delete(string name);
    }
}