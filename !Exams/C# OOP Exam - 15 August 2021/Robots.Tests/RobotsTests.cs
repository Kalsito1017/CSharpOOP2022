namespace Robots.Tests
{
    using System;
    using NUnit.Framework;

    public class RobotsTests
    {
        private RobotManager robotsManager;
        private Robot robot1;
        private Robot robot2;

        [SetUp]
        public void SetUp()
        {
            this.robotsManager = new RobotManager(2);

            this.robot1 = new Robot("Robotche", 100);
            this.robot2 = new Robot("Robo", 10);
        }

        [TestCase(1)]
        [TestCase(0)]
        [TestCase(100)]
        public void ConstructorOfManagerShouldCreateARobotManagerProperlyWithNonNegativeCapacity(int capacity)
        {
            //Act
            RobotManager robotManager = new RobotManager(capacity);

            int expectedCapacity = capacity;
            int actualCapacity = robotManager.Capacity;

            int expectedCount = 0;
            int actualCount = robotManager.Count;

            //Assert
            Assert.IsNotNull(robotManager);
            Assert.AreEqual(expectedCapacity, actualCapacity);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void CapacitySetterShouldThrowAnExceptionWithNegativeCapacity(int capacity)
        {
            //Act and Assert
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robotManager = new RobotManager(capacity);
            }, "Invalid capacity!");
        }

        [Test]
        public void AddMethodShouldAddARobotProperlyWhenThereIsEnoughPlaceAndTheRobotDoesNotExist()
        {
            //Act
            this.robotsManager.Add(this.robot1);

            int expectedCount = 1;
            int actualCount = robotsManager.Count;

            int expectedCapacity = 2;
            int actualCapacity = robotsManager.Capacity;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void AddMethodShouldThrowAnExceptionWhenTheCapacityIsZero()
        {
            //Act
            RobotManager robotManager = new RobotManager(0);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(this.robot1);
            }, "Not enough capacity!");
        }
        [Test]
        public void AddMethodShouldThrowAnExceptionWhenThereIsNotEnoughSpace()
        {
            //Act
            this.robotsManager.Add(this.robot1);
            this.robotsManager.Add(this.robot2);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotsManager.Add(new Robot("Rob", 40));
            }, "Not enough capacity!");
        }

        [Test]
        public void AddMethodShouldThrowAnExceptionWhenTheRobotAlreadyExists()
        {
            //Act
            this.robotsManager.Add(this.robot1);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotsManager.Add(new Robot(this.robot1.Name, 5));
            }, $"There is already a robot with name {this.robot1.Name}!");
        }

        [Test]
        public void RemoveMethodShouldRemoveARobotProperlyWhenTheRobotExists()
        {
            //Arrange
            this.robotsManager.Add(this.robot1);
            this.robotsManager.Add(this.robot2);

            //Act
            this.robotsManager.Remove(this.robot1.Name);

            int expectedCount = 1;
            int actualCount = this.robotsManager.Count;

            int expectedCapacity = 2;
            int actualCapacity = robotsManager.Capacity;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void RemoveMethodShouldThrowAnExceptionWhenTheRobotDoesNotExists()
        {
            //Act
            this.robotsManager.Add(this.robot1);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotsManager.Remove(this.robot2.Name);
            }, $"Robot with the name {this.robot2.Name} doesn't exist!");
        }

        [Test]
        public void RemoveMethodShouldThrowAnExceptionWhenTheRobotManagerIsEmpty()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotsManager.Remove(this.robot2.Name);
            }, $"Robot with the name {this.robot2.Name} doesn't exist!");
        }

        [Test]
        public void WorkMethodShouldDecreaseBatteryChargeProperlyWhenTheRobotExistsAndItsBatteryIsHigherThanUsage()
        {
            //Arrange
            this.robotsManager.Add(this.robot1);

            //Act
            this.robotsManager.Work(this.robot1.Name, "compute", 30);

            int expectedBattery = 70;
            int actualBattery = this.robot1.Battery;

            //Assert
            Assert.AreEqual(expectedBattery, actualBattery);
        }

        [Test]
        public void WorkMethodShouldThrowAnExceptionWhenTheRobotDoesNotExists()
        {
            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotsManager.Work(this.robot2.Name, "work", 30);
            }, $"Robot with the name {this.robot2.Name} doesn't exist!");
        }

        [Test]
        public void WorkMethodShouldThrowAnExceptionWhenTheBatteryChargeIsLowerThanUsage()
        {
            //Act
            this.robotsManager.Add(this.robot2);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotsManager.Work(this.robot2.Name, "work", 50);
            }, $"{this.robot2.Name} doesn't have enough battery!");
        }

        [Test]
        public void ChargeMethodShouldRechargeTheBatteryWhenTheRobotExists()
        {
            //Arrange
            this.robotsManager.Add(this.robot1);

            //Act
            this.robotsManager.Work(this.robot1.Name, "compute", 30);
            this.robotsManager.Charge(this.robot1.Name);

            int expectedBattery = this.robot1.MaximumBattery;
            int actualBattery = this.robot1.Battery;

            //Assert
            Assert.AreEqual(expectedBattery, actualBattery);
        }

        [Test]
        public void ChargeMethodShouldThrowAnExceptionWhenTheRobotDoesNotExists()
        {
            //Act Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.robotsManager.Charge(this.robot1.Name);
            }, $"Robot with the name {this.robot1.Name} doesn't exist!");
        }
    }
}