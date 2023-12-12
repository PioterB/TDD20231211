using VehicleDiary.Logic;

namespace VehiclesDiary.Controllers
{
    public class VehiclePreview
    {
        public VehiclePreview(Vehicle item)
        {
            Name = item.Name;
        }

        public string Name { get; }
    }
}