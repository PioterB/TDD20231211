using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using VehicleDiary.Logic;

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
            TestDelegate action = () => new Car(invalidName);

            Assert.Throws<ArgumentException>(action);
        }

        [Test]
        [TestCase("x")]
        public void Ctor_ValidName_Contructed(string validName)
        {
            TestDelegate action = () => new Car(validName);

            Assert.DoesNotThrow(action);
        }

        [Test]
        public void Equals_Nothing_Negative()
        {
            object given = null;
            var unitUnderTest = new Car("Me");
            
            var read = unitUnderTest.Equals(given);

            Assert.IsFalse(read);
        }

        [Test]
        public void Equals_Me_Positive()
        {
            var unitUnderTest = new Car("Me");
            object given = unitUnderTest;

            var read = unitUnderTest.Equals(given);

            Assert.IsTrue(read);
        }

        [Test]
        public void Equals_Other_Negative()
        {
            var unitUnderTest = new Car("Me");
            object given = new object();

            var read = unitUnderTest.Equals(given);

            Assert.IsFalse(read);
        }

        [Test]
        public void Equals_SameName_Positive()
        {
            var unitUnderTest = new Car("Me");
            object given = new Car(unitUnderTest.Name);

            var read = unitUnderTest.Equals(given);

            Assert.IsTrue(read);
        }

        [Test]
        public void Equals_SameNameDifferentCasing_Positive()
        {
            var unitUnderTest = new Car("Me");
            object given = new Car(unitUnderTest.Name.ToLower());

            var read = unitUnderTest.Equals(given);

            Assert.IsTrue(read);
        }

        [Test]
        public void Equals_DifferentName_Negative()
        {
            var unitUnderTest = new Car("Me");
            object given = new Car("Other");

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
