namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warriorA;
        private Warrior warriorB;

        [SetUp]
        public void SetUp()
        {
            this.arena = new Arena();
            this.warriorA = new Warrior("Attacker", 80, 100);
            this.warriorB = new Warrior("Defender", 50, 100);
        }

        [Test]
        public void ConstructorShouldInitializeACollectionOfWarriors()
        {
            //Arrange
            Arena arena = new Arena();

            //Act
            List<Warrior> actualList = arena.Warriors.ToList();
            List<Warrior> expectedList = new List<Warrior>();

            int actualCount = arena.Count;
            int expectedCount = 0;

            //Assert
            CollectionAssert.AreEqual(expectedList, actualList, "Constructor initializes an empty collection of warriors");
            Assert.AreEqual(expectedCount, actualCount, "Constructor initializes an empty collection of warriors");
        }

        [Test]
        public void CountShouldReturnCountOfWarriorsOnTheArena()
        {
            //Act
            this.arena.Enroll(this.warriorA);
            this.arena.Enroll(this.warriorB);

            int actualCount = arena.Count;
            int expectedCount = 2;

            //Assert
            Assert.AreEqual(expectedCount, actualCount, "Count should return the number of warriors");
        }

        [Test]
        public void EnrollMethodShouldAddWarriorsInArenaCollection()
        {
            //Act
            this.arena.Enroll(this.warriorA);
            this.arena.Enroll(this.warriorB);

            List<Warrior> actualList = arena.Warriors.ToList();
            List<Warrior> expectedList = new List<Warrior>() { this.warriorA, this.warriorB };

            //Assert
            CollectionAssert.AreEqual(expectedList, actualList, "Enroll method should add warriors int the collection of warriors");
        }

        [Test]
        public void EnrollMethodShouldThrowAnExceptionWhenAddAnExistingWarrior()
        {
            //Act
            this.arena.Enroll(this.warriorA);

            //Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Enroll(this.warriorA);
            }, "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void FightMethodShouldStartAnAttack()
        {
            //Arrange
            this.arena.Enroll(this.warriorA);
            this.arena.Enroll(this.warriorB);

            //Act
            this.arena.Fight("Attacker", "Defender");

            int expectedHpA = 100 - this.warriorB.Damage;
            int actualHpA = this.warriorA.HP;

            int expectedHpB = 100 - this.warriorA.Damage;
            int actualHpB = this.warriorB.HP;

            //Assert
            Assert.AreEqual(expectedHpA, actualHpA, "Fight should decrease HP of every warrior.");
            Assert.AreEqual(expectedHpB, actualHpB, "Fight should decrease HP of every warrior.");
        }

        [Test]
        public void FightMethodShouldThrowAnExceptionIfOneOfTheWarriorIsNull()
        {
            //Arrange
            this.arena.Enroll(this.warriorA);
            this.arena.Enroll(this.warriorB);

            //Act and Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight("Attacker", "Noname");
            }, "There is no fighter with name NoName enrolled for the fights!");

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.arena.Fight("Noname", "Attacker");
            }, "There is no fighter with name NoName enrolled for the fights!");
        }
    }
}