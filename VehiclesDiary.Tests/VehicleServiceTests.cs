using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleDiary.Logic;
using VehiclesDiary.Tools.Persistence;

namespace VehiclesDiary.Tests
{
    public class VehicleServiceTests
    {
        private InMemoryRepository<string, Vehicle> _vehiclesRepository;
        private IVehiclesService _unitUnderTest;

        [OneTimeSetUp]
        public void SingleSetup()
        {
        }

        [SetUp]
        public void Setup()
        {
            _vehiclesRepository = new InMemoryRepository<string, Vehicle>();
            _unitUnderTest = new VehicleService(_vehiclesRepository);
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

        [Test]
        public void Delete_Has_Removed() 
        {
            var removedName = "x";
            _vehiclesRepository.Add(removedName, new Car(removedName));

            _unitUnderTest.Delete(removedName);

            Assert.IsFalse(_vehiclesRepository.Exists(removedName));
        }

        [Test]
        public void Delete_NotExists_Removed()
        {
            var other = "x";
            _vehiclesRepository.Add(other, new Car(other));

            _unitUnderTest.Delete("y");

            Assert.IsFalse(_vehiclesRepository.Exists("y"));
        }

        [Test]
        public void Delete_Has_OtherStays()
        {
            var removedName = "x";
            var other = "y";
            var other2 = "y2";
            _vehiclesRepository.Add(other2, new Car(other2));
            _vehiclesRepository.Add(removedName, new Car(removedName));
            _vehiclesRepository.Add(other, new Car(other));

            _unitUnderTest.Delete(removedName);

            Assert.IsTrue(_vehiclesRepository.Exists(other));
            Assert.IsTrue(_vehiclesRepository.Exists(other2));
        }

        [Test]
        public void Delete_Has_ReducedByOne()
        {
            var removedName = "x";
            var other = "y";
            var other2 = "y2";
            _vehiclesRepository.Add(other2, new Car(other2));
            _vehiclesRepository.Add(removedName, new Car(removedName));
            _vehiclesRepository.Add(other, new Car(other));

            _unitUnderTest.Delete(removedName);

            Assert.AreEqual(2, _vehiclesRepository.GetAll().Count());
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
