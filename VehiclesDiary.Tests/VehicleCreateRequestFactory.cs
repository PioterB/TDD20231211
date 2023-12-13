using System;
using VehiclesDiary.Logic;

namespace VehiclesDiary.Tests
{
    internal class VehicleCreateRequestFactory
    {
        public static VehicleCreationRequest Create(string name = null)
        {
            name = name ?? "from api";
            var instance = (VehicleCreationRequest)Activator.CreateInstance(typeof(VehicleCreationRequest), true);
            instance.Name = name;
            return instance;
        }

        public static VehicleCreationRequest Invalid(string name = null) 
        {
            var instance = (VehicleCreationRequest)Activator.CreateInstance(typeof(VehicleCreationRequest), true);
            instance.Name = name;
            return instance;
        }
    }
}
