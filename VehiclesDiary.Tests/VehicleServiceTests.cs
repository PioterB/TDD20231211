using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleDiary.Logic;

namespace VehiclesDiary.Tests
{
    public class VehicleServiceTests
    {
        private IVehiclesService _unitUnderTest;

        [OneTimeSetUp]
        public void SingleSetup()
        {
        }

        [SetUp]
        public void Setup()
        {
            _unitUnderTest = new VehicleService();
        }

        [Test]
        public void AddSingleVehicle()
        {
            var newItem = new Car("car");
            
            bool success = _unitUnderTest.Add(newItem);

            Assert.IsTrue(success);
        }

        [Test]
        public void PreventAddingDuplicates()
        {
            var duplicate = new Car("duplicate");
            _ = _unitUnderTest.Add(duplicate);
            
            bool failure = _unitUnderTest.Add(duplicate);

            Assert.IsFalse(failure);
        }

        [TearDown]
        public void Teardown()
        {
        }

        [OneTimeTearDown]
        public void SingleTeardown()
        {
        }
    }
}
