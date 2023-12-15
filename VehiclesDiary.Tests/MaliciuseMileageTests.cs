using NSubstitute;
using NUnit.Framework;
using VehiclesDiary.Logic.Events;
using VehiclesDiary.Logic.Vehicles;
using VehiclesDiary.Tools.Persistence;

namespace VehiclesDiary.Tests
{
    public class MaliciuseMileageTests
    {
        private IRepository<string, Vehicle> _vehiclesRepository;
        private MaliciuseMileage _unitUnderTest;

        [SetUp]
        public void Setup()
        {
            _vehiclesRepository = Substitute.For<IRepository<string, Vehicle>>();
            _unitUnderTest = new MaliciuseMileage(_vehiclesRepository);
        }

        [Test]
        public void NonBroken_OldMileage_Rejected()
        {
            var maliciousMileage = 1000;
            var given = VehicleEventRequestFactory.Create(mileage: maliciousMileage);
            var lastEvent = VehicleEventFactory.Create(mileage: maliciousMileage + 1);
            var vehicle = VehicleFactory.Create(lastEvent: lastEvent, name: given.Vehicle);
            _vehiclesRepository.Get(vehicle.Name).Returns(vehicle);

            var read = _unitUnderTest.NotBroken(given);

            Assert.IsFalse(read);
        }

        [Test]
        public void NonBroken_LatestMileage_Accepted()
        {
            var maliciousMileage = 1000;
            var given = VehicleEventRequestFactory.Create(mileage: maliciousMileage);
            var lastEvent = VehicleEventFactory.Create(mileage: maliciousMileage - 1);
            var vehicle = VehicleFactory.Create(lastEvent: lastEvent, name: given.Vehicle);
            _vehiclesRepository.Get(vehicle.Name).Returns(vehicle);

            var read = _unitUnderTest.NotBroken(given);

            Assert.IsTrue(read);
        }
    }
}
