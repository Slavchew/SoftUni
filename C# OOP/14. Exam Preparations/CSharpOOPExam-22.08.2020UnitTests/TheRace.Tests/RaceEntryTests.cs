using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddDriverMethodShouldThrowExceptionWhenNullIsPassed()
        {

            Assert.Throws<InvalidOperationException>(() =>
            {
                var raceEntry = new RaceEntry();
                raceEntry.AddDriver(null);
            });
        }

        [Test]
        public void AddDriverMethodShouldThrowExceptionWhenDriverAlreadyExist()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var raceEntry = new RaceEntry();
                var unitCar = new UnitCar("model", 10, 10);
                var unitDriver = new UnitDriver("Gosho", unitCar);

                raceEntry.AddDriver(unitDriver);
                raceEntry.AddDriver(unitDriver);
            });
        }

        [Test]
        public void AddDriverMethodShouldWork()
        {
            var raceEntry = new RaceEntry();

            var unitCar = new UnitCar("model", 10, 10);
            var unitDriver = new UnitDriver("Gosho", unitCar);

            var result = raceEntry.AddDriver(unitDriver);

            Assert.AreEqual("Driver Gosho added in race.", result);
            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        public void CalculateAverageHorsePowerShouldThrowExceptionWhenParticipantsAreNotEnough()
        {
            var raceEntry = new RaceEntry();

            var unitCar = new UnitCar("model", 10, 10);
            var unitDriver = new UnitDriver("Gosho", unitCar);

            var result = raceEntry.AddDriver(unitDriver);

            Assert.Throws<InvalidOperationException>(() =>
            {
                raceEntry.CalculateAverageHorsePower();
            });
        }

        [Test]
        public void CalculateAverageHorsePowerShouldWork()
        {
            var raceEntry = new RaceEntry();

            var unitCar = new UnitCar("VW", 100, 2000);
            var unitDriver = new UnitDriver("Kiro", unitCar);

            var unitCar2 = new UnitCar("BMW", 100, 3000);
            var unitDriver2 = new UnitDriver("Ivan", unitCar);

            var unitCar3 = new UnitCar("Lada Sedan", 100, 6300);
            var unitDriver3 = new UnitDriver("Stoqn", unitCar);


            raceEntry.AddDriver(unitDriver);
            raceEntry.AddDriver(unitDriver2);
            raceEntry.AddDriver(unitDriver3);

            var result = raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(100, result);
        }
    }
}