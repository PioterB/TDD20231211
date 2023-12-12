using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using VehicleDiary.Logic;
using VehiclesDiary.Controllers;
using VehiclesDiary.Logic;
using VehiclesDiary.Tools;
using VehiclesDiary.Tools.Persistence;

namespace VehiclesDiary.Tests
{
    public class VehiclesControllerTests
    {
        private IRepository<string, Vehicle> _vehiclesRepository;
        private IVehiclesService _vehicleService;
        private VehiclesController _unitUnderTests;

        [OneTimeSetUp]
        public void SingleSetup()
        {
        }

        [SetUp]
        public void Setup()
        {
            _vehiclesRepository = Substitute.For<IRepository<string, Vehicle>>();
            _vehicleService = Substitute.For<IVehiclesService>();
            _unitUnderTests = new VehiclesController(_vehiclesRepository, _vehicleService);
        }

        [Test]
        public void Add_Nothinig_BadResult()
        {
            VehicleCreationRequest nothing = null;

            var response = _unitUnderTests.Add(nothing);

            Assert.IsInstanceOf<BadRequestResult>(response);
        }

        [Test]
        public void Add_Invalid_BadResult()
        {
            _vehicleService.Add((VehicleCreationRequest)null).ReturnsForAnyArgs(Result<Vehicle>.Failure());
            VehicleCreationRequest invalid = new VehicleCreationRequest() { Name = ""};

            var response = _unitUnderTests.Add(invalid);

            Assert.IsInstanceOf<BadRequestResult>(response);
        }

        [Test]
        public void Add_Correct_OkResult()
        {
            _vehicleService.Add((VehicleCreationRequest)null).ReturnsForAnyArgs(Result<Vehicle>.Success(VehicleFactory.Create()));
            VehicleCreationRequest valid = new VehicleCreationRequest() { Name = "x" };

            var response = _unitUnderTests.Add(valid);

            Assert.IsInstanceOf<OkObjectResult>(response);
        }

        [Test]
        public void Get_Items_AllReturned()
        {
            var items = new List<Vehicle>() { VehicleFactory.Create() };
            _vehiclesRepository.GetAll().Returns(items);

            var read = _unitUnderTests.Get();

            Assert.AreEqual(items.Count, read.Count());
        }

        [Test]
        public void Get_Items_AllPresent()
        {
            var items = new List<Vehicle>() { VehicleFactory.Create() };
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