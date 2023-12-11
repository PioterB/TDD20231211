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

            Assert.IsTrue(_vehiclesRepository.Exists(removedName));
        }

        [Test]
        public void Delete_Has_OthersPersisted()
        {
            var other = new Car("name");
            var toRemove = new Car("toRemove");
            var items = new List<Car>() { other, toRemove };

            _ = _unitUnderTest.Add(toRemove);

            _unitUnderTest.Delete(toRemove.Name);

            Assert.AreEqual(other, items.First());
        }

        [Test]
        public void Delete_Has_CollectionReduced()
        {
            var other = new Car("name");
            var toRemove = new Car("toRemove");
            var items = new List<Car>() { other, toRemove };

            _ = _unitUnderTest.Add(toRemove);

            _unitUnderTest.Delete(toRemove.Name);

            Assert.AreEqual(1, items.Count);
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
