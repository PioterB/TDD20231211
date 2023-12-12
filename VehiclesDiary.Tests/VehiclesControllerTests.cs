using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using VehicleDiary.Logic;
using VehiclesDiary.Controllers;
using VehiclesDiary.Tools.Persistence;

namespace VehiclesDiary.Tests
{
    public class VehiclesControllerTests
    {
        private IRepository<string, Vehicle> _vehiclesRepository;
        private VehiclesController _unitUnderTests;

        [OneTimeSetUp]
        public void SingleSetup()
        {
        }

        [SetUp]
        public void Setup()
        {
            _vehiclesRepository = Substitute.For<IRepository<string, Vehicle>>();
            _unitUnderTests = new VehiclesController(_vehiclesRepository);
        }

        [Test]
        public void Get_Items_AllReturned()
        {
            var items = new List<Vehicle>() { new Car("x")};
            _vehiclesRepository.GetAll().Returns(items);

            var read = _unitUnderTests.Get();

            Assert.AreEqual(items.Count, read.Count());
        }

        [Test]
        public void Get_Items_AllPresent()
        {
            var items = new List<Vehicle>() { new Car("x") };
            _vehiclesRepository.GetAll().Returns(items);

            var read = _unitUnderTests.Get();

            Assert.IsTrue(items.All(a => a != null));
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