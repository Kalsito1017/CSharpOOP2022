namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car ferrari;

        [SetUp]
        public void SetUp()
        {
            this.ferrari = new Car("Ferrari", "Enzo", 10, 80);
        }

        [TestCase("Opel", "Corsa", 5.1, 50.5)]
        [TestCase("Ferrari", "Enzo", 12, 80)]
        public void ConstructorShouldInitializeACar(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Arrange
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            //Act
            string actualMake = car.Make;
            string expectedMake = make;

            string actualModel = car.Model;
            string expectedModel = model;

            double actualFuelConsumption = car.FuelConsumption;
            double expectedFuelConsumption = fuelConsumption;

            double actualFuelCapacity = car.FuelCapacity;
            double expectedFuelCapacity = fuelCapacity;

            double actualFuelAmount = car.FuelAmount;
            double expectedFuelAmount = 0;

            //Assert
            Assert.AreEqual(expectedMake, actualMake, "Constructor sets this property correctly");
            Assert.AreEqual(expectedModel, actualModel, "Constructor sets this property correctly");
            Assert.AreEqual(expectedFuelConsumption, actualFuelConsumption, "Constructor sets this property correctly");
            Assert.AreEqual(expectedFuelCapacity, actualFuelCapacity, "Constructor sets this property correctly");
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount, "Constructor sets this property correctly");
        }

        [Test]
        public void ConstructorShouldInitializeACarFuelAmount()
        {
            //Act
            double actualFuelAmount = this.ferrari.FuelAmount;
            double expectedFuelAmount = 0;

            //Assert
            Assert.AreEqual(expectedFuelAmount, actualFuelAmount, "Private constructor sets this property correctly");
        }

        [TestCase("", "Enzo", 12, 80)]
        [TestCase(null, "Enzo", 12, 80)]
        public void ConstructorShouldThrowAnExeprionWithBlankMake(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Act and Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Make cannot be null or empty!");
        }

        [TestCase("Ferrari", "", 12, 80)]
        [TestCase("Ferrari", null, 12, 80)]
        public void ConstructorShouldThrowAnExeprionWithBlankModel(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Act and Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Model cannot be null or empty!");
        }

        [TestCase("Ferrari", "Enzo", 0, 80)]
        [TestCase("Ferrari", "Enzo", -12, 80)]
        public void ConstructorShouldThrowAnExeprionWithZeroOrNegativeConsumtion(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Act and Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Fuel consumption cannot be zero or negative!");
        }

        [TestCase("Ferrari", "Enzo", 12, 0)]
        [TestCase("Ferrari", "Enzo", 12, -80)]
        public void ConstructorShouldThrowAnExeprionWithZeroOrNegativeCapacity(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            //Act and Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Fuel capacity cannot be zero or negative!");
        }

        [TestCase(1.2)]
        [TestCase(79.9)]
        [TestCase(80)]
        [TestCase(81)]
        [TestCase(100)]
        public void RefuelMethodShouldIncreaseFuelAmountInCaseFuelIsPositiveQuantity(double fuelToRefuel)
        {
            //Arrange
            double startAmount = this.ferrari.FuelAmount;

            //Act
            this.ferrari.Refuel(fuelToRefuel);

            double actualAmount = this.ferrari.FuelAmount;
            double currentAmount = startAmount + fuelToRefuel;
            double expectedAmount = currentAmount;

            if (currentAmount > this.ferrari.FuelCapacity)
            {
                expectedAmount = this.ferrari.FuelCapacity;
            }

            //Assert
            Assert.AreEqual(expectedAmount, actualAmount, "Refuel method works correctly!");
        }

        [TestCase(0)]
        [TestCase(-79.9)]
        [TestCase(-1.99)]
        public void RefuelMethodShouldThrowAnExceptionInCaseFuelIsZeroOrNegativeNumber(double fuelToRefuel)
        {
            //Act an Assert
            Assert.Throws<ArgumentException>(() =>
            {
                this.ferrari.Refuel(fuelToRefuel);
            }, "Fuel amount cannot be zero or negative!");
        }

        [TestCase(100, 10)]
        [TestCase(800, 80)]
        [TestCase(600, 80)]
        [TestCase(0, 1)]
        public void DriveMethodShouldDecreaseFuelAmountInCaseFuelAmountIsEnough(double distance, double fuelToRefuel)
        {
            //Arrange
            double fuelNeeded = (distance / 100) * this.ferrari.FuelConsumption;
            this.ferrari.Refuel(fuelToRefuel);
            double startAmount = this.ferrari.FuelAmount;

            //Act
            this.ferrari.Drive(distance);

            double actualAmount = this.ferrari.FuelAmount;
            double expectedAmount = startAmount - fuelNeeded;

            //Assert
            Assert.AreEqual(expectedAmount, actualAmount, "Drive method works correctly!");
        }

        [TestCase(1000)]
        public void DriveMethodShouldThrowAnExceptionInCaseFuelAmountIsNotEnough(double distance)
        {
            //Act and Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.ferrari.Drive(distance);
            }, "You don't have enough fuel to drive!");
        }
    }
}