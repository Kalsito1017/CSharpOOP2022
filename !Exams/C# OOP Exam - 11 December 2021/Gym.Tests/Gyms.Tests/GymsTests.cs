using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        private Gym testGym;
        private Athlete athlete1;
        private Athlete athlete2;

        [SetUp]
        public void SetUp()
        {
            this.testGym = new Gym("Gym", 2);
            this.athlete1 = new Athlete("Ivan");
            this.athlete2 = new Athlete("Stoyan");
        }

        [TestCase("Gym", 0)]
        [TestCase("BestGym", 10)]
        public void ConstructorShouldCreateAGymProperlyWithNotNullOtEmptyNameAndNonNegativeCapacity(string name, int capacity)
        {
            //Arrange and Act
            Gym gym = new Gym(name, capacity);

            string expectedName = name;
            string actualName = gym.Name;

            int expectedCapacity = capacity;
            int actualCapacity = gym.Capacity;

            int expectedCount = 0;
            int actualCount = gym.Count;

            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedCapacity, actualCapacity);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [TestCase(null, 1)]
        [TestCase("", 10)]
        public void NameSetterShouldThrowAnExceptionWithNullOtEmptyName(string name, int capacity)
        {
            //Act anf Assert
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(name, capacity);
            }, "Invalid gym name.");
        }

        [TestCase("Gym", -1)]
        [TestCase(" ", -10)]
        public void CapacitySetterShouldThrowAnExceptionWithNegativeValue(string name, int capacity)
        {
            //Act anf Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym(name, capacity);
            }, "Invalid gym capacity.");
        }

        [Test]
        public void AddAthleteMethodShouldAddProperlyAthletesWhenThereIsEnoughCapacity()
        {
            //Act
            this.testGym.AddAthlete(this.athlete1);
            this.testGym.AddAthlete(this.athlete2);

            int expectedCount = 2;
            int actualCount = this.testGym.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddAthleteMethodShouldThrowAnExceptionWhenThereIsNotEnoughCapacity()
        {
            //Arrange
            this.testGym.AddAthlete(this.athlete1);
            this.testGym.AddAthlete(this.athlete2);

            //Act and Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testGym.AddAthlete(new Athlete("Georgi"));
            }, "The gym is full.");
        }

        [Test]
        public void RemoveAthleteMethodShouldRemoveProperlyAthletesWhenAthleteIsInGym()
        {
            //Arrange
            this.testGym.AddAthlete(this.athlete1);
            this.testGym.AddAthlete(this.athlete2);

            //Act
            this.testGym.RemoveAthlete(this.athlete1.FullName);

            int expectedCount = 1;
            int actualCount = this.testGym.Count;

            //Assert
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void RemoveAthleteMethodShouldThrowAnExceptionWhenRemoveAthleteWhoIsNotInGym()
        {
            //Arrange
            this.testGym.AddAthlete(this.athlete1);

            //Act and Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testGym.RemoveAthlete(this.athlete2.FullName);
            }, $"The athlete {this.athlete2.FullName} doesn't exist.");
        }

        [Test]
        public void RemoveAthleteMethodShouldThrowAnExceptionWhenGymIsEmpty()
        {
            //Act and Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testGym.RemoveAthlete(this.athlete2.FullName);
            }, $"The athlete {this.athlete2.FullName} doesn't exist.");
        }

        [Test]
        public void InjureAthleteMethodShouldSetInjuredStatusProperlyWhenAthleteIsInGym()
        {
            //Arrange
            this.testGym.AddAthlete(this.athlete1);
            this.testGym.AddAthlete(this.athlete2);

            //Act
            Athlete injuredAthlete = this.testGym.InjureAthlete(this.athlete1.FullName);

            string expectedInjuredName = this.athlete1.FullName;
            string actualInjuredName = injuredAthlete.FullName;

            //Assert
            Assert.IsTrue(this.athlete1.IsInjured);
            Assert.AreEqual(expectedInjuredName, actualInjuredName);
            Assert.IsFalse(this.athlete2.IsInjured);
        }

        [Test]
        public void InjureAthleteMethodShouldThrowAnExceptionWhenInjureAthleteWhoIsNotInGym()
        {
            //Act and Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.testGym.InjureAthlete(this.athlete2.FullName);
            }, $"The athlete {this.athlete2.FullName} doesn't exist.");
        }

        [Test]
        public void ReportMethodShouldReturnCorrectReportAboutTheGymWithAthletes()
        {
            //Arrange
            this.testGym.AddAthlete(this.athlete1);
            this.testGym.AddAthlete(this.athlete2);

            //Act
            this.testGym.InjureAthlete(this.athlete1.FullName);

            string expectedReport = "Active athletes at Gym: Stoyan";
            string actualReport = this.testGym.Report();

            //Assert
            Assert.AreEqual(expectedReport, actualReport);
        }

        [Test]
        public void ReportMethodShouldReturnCorrectReportAboutTheGymWithoutAthletes()
        {
            //Act
            string expectedReport = "Active athletes at Gym: ";
            string actualReport = this.testGym.Report();

            //Assert
            Assert.AreEqual(expectedReport, actualReport);
        }
    }
}
