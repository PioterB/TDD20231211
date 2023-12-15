using NSubstitute;
using NUnit.Framework;
using System;
using VehiclesDiary.Logic;
using VehiclesDiary.Logic.Events;
using VehiclesDiary.Logic.Vehicles;
using VehiclesDiary.Tools.Persistence;

namespace VehiclesDiary.Tests
{
    public class VehicleServiceTests
    {
        private IRepository<string, Vehicle> _vehiclesRepository;
        private IValidator<VehicleEventRequest> _eventRequestValidator;
        private VehicleService _unitUnderTest;

        [OneTimeSetUp]
        public void SingleSetup()
        {
        }

        [SetUp]
        public void Setup()
        {
            _vehiclesRepository = Substitute.For<IRepository<string, Vehicle>>();
            _eventRequestValidator = Substitute.For<IValidator<VehicleEventRequest>>();
            _unitUnderTest = new VehicleService(_vehiclesRepository, _eventRequestValidator);
        }

        [Test]
        public void Add_NotExisting_Added()
        {
            var newItem = VehicleFactory.Create();
            
            bool success = _unitUnderTest.Add(newItem);
            
            Assert.IsTrue(success);
        }

        [Test]
        public void Add_Duplicate_Ignored()
        {
            var duplicatedName = "d";

            _vehiclesRepository.Exists(duplicatedName).Returns(true);
            
            bool failure = _unitUnderTest.Add(VehicleFactory.Create(duplicatedName));

            Assert.IsFalse(failure);
        }

        [Test]
        public void Delete_Has_Removed() 
        {
            var removedName = "x";
            
            _unitUnderTest.Delete(removedName);

            _vehiclesRepository.Received(1).Remove(removedName);
        }

        [Test]
        public void Delete_NotExists_Removed()
        {
            var other = "x";
            _vehiclesRepository.Add(other, VehicleFactory.Create(other));

            var read = _unitUnderTest.Delete("y");

            Assert.IsTrue(read);
            _vehiclesRepository.DidNotReceive().Remove(other);
        }

        [Test]
        public void NewEvent_Valid_Created()
        {
            var given = VehicleEventRequestFactory.Create();

            var read = _unitUnderTest.NewEvent(given);

            Assert.IsFalse(read.Fail);
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
