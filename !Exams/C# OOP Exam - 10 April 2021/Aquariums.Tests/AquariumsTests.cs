namespace Aquariums.Tests
{
    namespace Aquariums.Tests
    {
        using System;
        using NUnit.Framework;

        [TestFixture]
        public class AquariumsTests
        {
            private Aquarium aquarium;
            private Fish fish1;
            private Fish fish2;

            [SetUp]
            public void SetUp()
            {
                this.aquarium = new Aquarium("Aquarium", 2);

                this.fish1 = new Fish("Nemo");
                this.fish2 = new Fish("Dori");
            }

            [TestCase("SuperTank", 1000)]
            [TestCase("  ", 0)]
            [TestCase("PoorTank", 1)]
            public void ConstructorShouldCreateAnAquariumCorrectly(string name, int capacity)
            {
                //Act
                Aquarium aquarium1 = new Aquarium(name, capacity);

                //Assert
                Assert.IsNotNull(aquarium);
                Assert.AreEqual(name, aquarium1.Name);
                Assert.AreEqual(capacity, aquarium1.Capacity);
                Assert.AreEqual(0, aquarium1.Count);
            }

            [TestCase("")]
            [TestCase(null)]
            public void NameSetterShouldThrowAnExceptionWhenNameIsNullOrEmpty(string name)
            {
                //Act and Assert
                Assert.Throws<ArgumentNullException>(
                    () =>
                    {
                        Aquarium aquarium1 = new Aquarium(name, 50);
                    }, "Invalid aquarium name!");
            }

            [TestCase(-1)]
            [TestCase(-100)]
            public void CapacitySetterShouldThrowAnExceptionWhenValueIsBelowZero(int capacity)
            {
                //Act and Assert
                Assert.Throws<ArgumentException>(
                    () =>
                    {
                        Aquarium aquarium1 = new Aquarium("Aquarium", capacity);
                    }, "Invalid aquarium capacity!");
            }

            [Test]
            public void AddMethodShouldAddAFishInTheAquariumWhenThereIsEnoughCapacity()
            {
                //Act
                this.aquarium.Add(this.fish1);
                this.aquarium.Add(this.fish2);

                //Assert
                Assert.AreEqual(2, aquarium.Count);
            }

            [Test]
            public void AddMethodShouldThrowAnExceptionWhenThereIsNotEnoughCapacity()
            {
                //Arrange
                this.aquarium.Add(this.fish1);
                this.aquarium.Add(this.fish2);

                //Act and Assert
                Assert.Throws<InvalidOperationException>(() =>
                {
                    this.aquarium.Add(this.fish1);
                }, "Aquarium is full!");
            }

            [Test]
            public void RemoveMethodShouldRemoveAFishIfItIsAlreadyInTheAquarium()
            {
                //Arrange
                this.aquarium.Add(this.fish1);
                this.aquarium.Add(this.fish2);

                //Act
                this.aquarium.RemoveFish(this.fish1.Name);

                //Assert
                Assert.AreEqual(1, aquarium.Count);
            }

            [Test]
            public void RemoveMethodShouldThrowAnExceptionIfFishIsNotInTheAquarium()
            {
                //Arrange
                this.aquarium.Add(this.fish1);

                //Act and Assert
                Assert.Throws<InvalidOperationException>(() =>
                {
                    this.aquarium.RemoveFish(this.fish2.Name);
                }, $"Fish with the name {this.fish2.Name} doesn't exist!");
            }

            [Test]
            public void SellFishMethodShouldChangeTheStatusOfTheFishToUnavailable()
            {
                //Arrange
                this.aquarium.Add(this.fish1);
                this.aquarium.Add(this.fish2);

                //Act
                this.aquarium.SellFish(this.fish1.Name);

                //Assert
                Assert.IsFalse(this.fish1.Available);
                Assert.AreEqual(this.fish1.Name, this.aquarium.SellFish(this.fish1.Name).Name);
            }

            [Test]
            public void SellMethodShouldThrowAnExceptionIfFishIsNotInTheAquarium()
            {
                //Arrange
                this.aquarium.Add(this.fish1);

                //Act and Assert
                Assert.Throws<InvalidOperationException>(() =>
                {
                    this.aquarium.SellFish(this.fish2.Name);
                }, $"Fish with the name {this.fish2.Name} doesn't exist!");
            }

            [Test]
            public void ReportMethodShouldReturnCorrectInformation()
            {
                //Arrange
                this.aquarium.Add(this.fish1);
                this.aquarium.Add(this.fish2);

                //Act
                string actualResult = this.aquarium.Report();
                string expectedResult = $"Fish available at {this.aquarium.Name}: {this.fish1.Name}, {this.fish2.Name}";

                //Assert
                Assert.AreEqual(expectedResult, actualResult);
            }
        }
    }
}
