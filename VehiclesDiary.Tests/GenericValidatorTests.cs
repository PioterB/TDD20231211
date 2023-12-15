using NSubstitute;
using NUnit.Framework;
using VehiclesDiary.Logic;

namespace VehiclesDiary.Tests
{
    public class GenericValidatorTests
    {
        private IValidationRule<object> _rule;
        private GenericValidator<object> _unitUnderTest;

        [SetUp]
        public void Setup()
        {
            _rule = Substitute.For<IValidationRule<object>>();
            _unitUnderTest = new GenericValidator<object>(new[] { _rule });
        }

        [Test]
        public void Validate_NonBrokenRule_Accepted()
        {
            _rule.NotBroken(null).ReturnsForAnyArgs(true);
            
            var read = _unitUnderTest.Validate(new object());

            Assert.IsTrue(read);
        }

        [Test]
        public void Validate_BrokenRule_Rejected()
        {
            _rule.NotBroken(null).ReturnsForAnyArgs(false);

            var read = _unitUnderTest.Validate(new object());

            Assert.IsFalse(read);
        }

        //[Test]
        //public void Validate_FromFuture_Rejected()
        //{
        //    var futureTime = DateTime.Now.AddDays(2);
        //    var given = VehicleEventRequestFactory.Create(created: futureTime);

        //    var read = _unitUnderTest.Validate(given);

        //    Assert.IsFalse(read);
        //}

        //[Test]
        //public void Validate_MaliciousMileage_Rejected()
        //{
        //    var maliciousMileage = 1000;
        //    var given = VehicleEventRequestFactory.Create(mileage: maliciousMileage);
        //    var lastEvent = VehicleEventFactory.Create(mileage: maliciousMileage + 1);
        //    var vehicle = VehicleFactory.Create(lastEvent: lastEvent, name: given.Vehicle);
        //    _rules.Exists(vehicle.Name).Returns(true);
        //    _rules.Get(vehicle.Name).Returns(vehicle);

        //    var read = _unitUnderTest.Validate(given);

        //    Assert.IsFalse(read);
        //}

        //[Test]
        //public void Validate_NoVehicle_Rejected()
        //{
        //    var missingVehicle = string.Empty;
        //    var given = VehicleEventRequestFactory.Create(vehicle: missingVehicle);

        //    var read = _unitUnderTest.Validate(given);

        //    Assert.IsFalse(read);
        //}

        //[Test]
        //public void Validate_UnknownVehicle_Rejected()
        //{
        //    var unknownVehicle = "who are you?";
        //    _rules.Exists(unknownVehicle).Returns(false);
        //    var given = VehicleEventRequestFactory.Create(vehicle: unknownVehicle);

        //    var read = _unitUnderTest.Validate(given);

        //    Assert.IsFalse(read);
        //}

        //[Test]
        //public void Validate_MissingDescription_Rejected()
        //{
        //    var missingDescription = string.Empty;
        //    var given = VehicleEventRequestFactory.Create(description: missingDescription);

        //    var read = _unitUnderTest.Validate(given);

        //    Assert.IsFalse(read);
        //}

        //[Test]
        //public void Validate_ToBigDescription_Rejected()
        //{
        //    var bigDescription = /* TODO how make big description? */ string.Empty;
        //    var given = VehicleEventRequestFactory.Create(description: bigDescription);

        //    var read = _unitUnderTest.Validate(given);

        //    Assert.IsFalse(read);
        //}

        //[Test]
        //public void Validate_Valid_Accepted()
        //{
        //    var given = VehicleEventRequestFactory.Create();

        //    var read = _unitUnderTest.Validate(given);

        //    Assert.IsTrue(read);
        //}
    }
}
