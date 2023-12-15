using NUnit.Framework;
using System;
using VehiclesDiary.Logic.Vehicles;

namespace VehiclesDiary.Tests
{
    public class VehicleTests
    {
        [OneTimeSetUp]
        public void SingleSetup()
        {
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(null, Description = "nothing name")]
        [TestCase("", Description = "missing name")]
        [TestCase(" ", Description = "empty name")]
        public void Ctor_InvalidName_Rejected(string invalidName)
        {
            TestDelegate action = () => new Car(invalidName, "make", "model");

            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        [TestCase("x")]
        public void Ctor_ValidName_Contructed(string validName)
        {
            TestDelegate action = () => new Car(validName, "make", "model");

            Assert.DoesNotThrow(action);
        }

        [Test]
        public void Equals_Nothing_Negative()
        {
            object given = null;
            var unitUnderTest = VehicleFactory.Create();
            
            var read = unitUnderTest.Equals(given);

            Assert.IsFalse(read);
        }

        [Test]
        public void Equals_Me_Positive()
        {
            var unitUnderTest = VehicleFactory.Create();
            object given = unitUnderTest;

            var read = unitUnderTest.Equals(given);

            Assert.IsTrue(read);
        }

        [Test]
        public void Equals_Other_Negative()
        {
            var unitUnderTest = VehicleFactory.Create();
            object given = new object();

            var read = unitUnderTest.Equals(given);

            Assert.IsFalse(read);
        }

        [Test]
        public void Equals_SameName_Positive()
        {
            var unitUnderTest = VehicleFactory.Create("Me");
            object given = VehicleFactory.Create(unitUnderTest.Name);

            var read = unitUnderTest.Equals(given);

            Assert.IsTrue(read);
        }

        [Test]
        public void Equals_SameNameDifferentCasing_Positive()
        {
            var unitUnderTest = VehicleFactory.Create("XXX");
            object given = VehicleFactory.Create(unitUnderTest.Name.ToLower());

            var read = unitUnderTest.Equals(given);

            Assert.IsTrue(read);
        }

        [Test]
        public void Equals_DifferentName_Negative()
        {
            var unitUnderTest = VehicleFactory.Create("me");
            object given = VehicleFactory.Create("other");

            var read = unitUnderTest.Equals(given);

            Assert.IsFalse(read);
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
