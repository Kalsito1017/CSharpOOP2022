using NUnit.Framework;

namespace RepairShop.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class Tests
    {
        public class RepairsShopTests
        {
            private Garage garage;
            private Car car1;
            private Car car2;

            [SetUp]
            public void SetUp()
            {
                this.garage = new Garage("Best", 2);
                this.car1 = new Car("Ferrari", 1);
                this.car2 = new Car("Mercedes", 2);
            }

            [TestCase("GoodGarage", 5)]
            [TestCase("G", 1)]
            [TestCase("  ", 5)]
            public void ConstructorShouldCreateAGarage(string name, int mechanics)
            {
                //Arrange
                Garage garage = new Garage(name, mechanics);

                //Act
                string expectedName = name;
                string actualName = garage.Name;

                int expectedMechanics = mechanics;
                int actualMechanics = garage.MechanicsAvailable;

                int expectedCars = 0;
                int actualCars = garage.CarsInGarage;

                //Assert
                Assert.AreEqual(expectedName, actualName);
                Assert.AreEqual(expectedMechanics, actualMechanics);
                Assert.AreEqual(expectedCars, actualCars);
            }

            [TestCase(null, 5)]
            [TestCase("", 5)]
            public void NameSetterShouldThrowAnExceptionWithNullOrEmptyName(string name, int mechanics)
            {
                //Act and Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(name, mechanics);
                }, "Invalid garage name.");
            }

            [TestCase("Best", 0)]
            [TestCase("Best", -5)]
            public void MechanicsAvailableSetterShouldThrowAnExceptionWithZeroOrNegativeMechanics(string name, int mechanics)
            {
                //Act and Assert
                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage(name, mechanics);
                }, "At least one mechanic must work in the garage.");
            }

            [Test]
            public void AddCarMethodShouldAddCarsInTheGarageWhenThereAreEnoughMechanics()
            {
                //Arrange an Act
                this.garage.AddCar(car1);
                this.garage.AddCar(car2);

                int expectedCars = 2;
                int actualCars = garage.CarsInGarage;

                //Assert
                Assert.AreEqual(expectedCars, actualCars);
            }

            [Test]
            public void AddCarMethodShouldThrowAnExceptionWhenThereAreNotEnoughMechanics()
            {
                //Arrange an Act
                this.garage.AddCar(car1);
                this.garage.AddCar(car2);

                //Assert
                Assert.Throws<InvalidOperationException>(() =>
                {
                    this.garage.AddCar(car2);
                }, "No mechanic available.");
            }

            [TestCase("Ferrari")]
            [TestCase("Mercedes")]
            public void FixCarMethodShouldReturnFixedCarWithNoIssues(string model)
            {
                //Arrange
                this.garage.AddCar(car1);
                this.garage.AddCar(car2);

                //Act
                Car fixedCar = this.garage.FixCar(model);

                int expectedCarIssue = 0;
                int actualCarIssue = fixedCar.NumberOfIssues;

                //Assert
                Assert.AreEqual(expectedCarIssue, actualCarIssue);
            }

            [TestCase("Opel")]
            [TestCase("Volvo")]
            public void FixCarMethodShouldShouldThrowExceptionWhenTheCarIsNotInGarage(string model)
            {
                //Arrange
                this.garage.AddCar(car1);
                this.garage.AddCar(car2);

                //Act and Assert
                Assert.Throws<InvalidOperationException>(() =>
                {
                    Car fixedCar = this.garage.FixCar(model);
                }, $"The car {model} doesn't exist.");
            }

            [Test]
            public void RemoveFixedCarMethodShouldRemoveFixedCarWithNoIssues()
            {
                //Arrange
                this.garage.AddCar(car1);
                this.garage.AddCar(car2);

                //Act
                Car fixedCar1 = this.garage.FixCar(car1.CarModel);
                //Car fixedCar2 = this.garage.FixCar(car2.CarModel);

                this.garage.RemoveFixedCar();

                int expectedCarLeft = 1;
                int actualCarLeft = this.garage.CarsInGarage;

                //Assert
                Assert.AreEqual(expectedCarLeft, actualCarLeft);
            }

            [Test]
            public void RemoveFixedCarMethodShouldThrowExceptionWhenThereAreNoCarsToRemove()
            {
                //Arrange
                this.garage.AddCar(car1);
                this.garage.AddCar(car2);

                //Act and Assert
                Assert.Throws<InvalidOperationException>(() =>
                {
                    this.garage.RemoveFixedCar();
                }, "No fixed cars available.");
            }

            [Test]
            public void ReportMethodShouldReturnReportsCorrectlyWithCars()
            {
                //Arrange
                this.garage.AddCar(car1);
                this.garage.AddCar(car2);

                //Act
                string expectedReport = $"There are 2 which are not fixed: Ferrari, Mercedes.";
                string actualReport = this.garage.Report();

                //Assert
                Assert.AreEqual(expectedReport, actualReport);
            }

            [Test]
            public void ReportMethodShouldReturnReportsCorrectlyWithNoCars()
            {
                //Act
                string expectedReport = $"There are 0 which are not fixed: .";
                string actualReport = this.garage.Report();

                //Assert
                Assert.AreEqual(expectedReport, actualReport);
            }
        }
    }
}