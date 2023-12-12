using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleDiary.Logic;
using VehiclesDiary.Controllers;

namespace VehiclesDiary.Tests
{
    public class VehiclePreviewTests
    {
        [Test]
        public void Ctor_Vehicle_NameMapped()
        {
            var vehicle = new Car("x");

            var preview = new VehiclePreview(vehicle);

            Assert.AreEqual(vehicle.Name, preview.Name);
        }
    }
}
