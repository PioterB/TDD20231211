using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using VehiclesDiary.Logic;
using VehiclesDiary.Controllers;

namespace VehiclesDiary.Tests
{
    public class VehiclePreviewTests
    {
        [Test]
        public void Ctor_Vehicle_NameMapped()
        {
            var vehicle = VehicleFactory.Create();

            var preview = new VehiclePreview(vehicle);

            Assert.AreEqual(vehicle.Name, preview.Name);
        }
    }
}
