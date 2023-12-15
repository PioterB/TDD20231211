using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using VehiclesDiary.Logic;
using VehiclesDiary.Logic.Events;
using VehiclesDiary.Controllers;
using VehiclesDiary.Tools.Persistence;
using VehiclesDiary.Logic.Vehicles;

namespace VehiclesDiary.Tests
{
    public class FunctionalTest
    {
        private VehiclesController _system;
        private InMemoryRepository<string, Vehicle> _vehiclesRepository;

        [SetUp]
        public void Setup()
        {
            _vehiclesRepository = new InMemoryRepository<string, Vehicle>();
            IEnumerable<IValidationRule<VehicleEventRequest>> eventValidationRules = new IValidationRule<VehicleEventRequest>[] 
            { 
                new IsFutureDate(), 
                new MaliciuseMileage(_vehiclesRepository), 
                new ToBigDescription() 
            };
            
            IValidator<VehicleEventRequest> eventRequestValidator = new GenericValidator<VehicleEventRequest>(eventValidationRules);
            var vehiclesService = new VehicleService(_vehiclesRepository, eventRequestValidator);
            _system = new VehiclesController(_vehiclesRepository, vehiclesService);
        }

        [Test]
        public void AcceptNewEvent()
        {
            var vehicle = VehicleFactory.Create();
            var request = VehicleEventRequestFactory.For(vehicle);
            _vehiclesRepository.Add(vehicle.Name, vehicle);

            var result = _system.NewEvent(request);

            Assert.IsInstanceOf<OkObjectResult>(result);
        }
    }
}
