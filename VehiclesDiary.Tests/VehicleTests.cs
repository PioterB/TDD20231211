using NUnit.Framework;
using System;
using System.Collections.Generic;
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
