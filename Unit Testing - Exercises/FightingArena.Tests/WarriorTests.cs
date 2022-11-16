namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Threading;

    [TestFixture]
    public class WarriorTests
    {
        [TestCase("Ivs", 50, 70)]
        [TestCase("Enemy", 60, 40)]
        public void ConstructorShouldInitializeAWarrior(string name, int damage, int hp)
        {
            //Arrange
            Warrior warrior = new Warrior(name, damage, hp);

            //Act
            string actualName = warrior.Name;
            string expectedName = name;

            int actualDamage = warrior.Damage;
            int expectedDamage = damage;

            int actualHp = warrior.HP;
            int expectedHp = hp;

            //Assert
            Assert.AreEqual(expectedName, actualName, "Constructor sets properly the name");
            Assert.AreEqual(expectedDamage, actualDamage, "Constructor sets properly the damage");
            Assert.AreEqual(expectedHp, actualHp, "Constructor sets properly the hp");
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void NameSetterShouldThrowAnExceptionWhenIsNullOrWhiteSpace(string name)
        {
            //Act and Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, 60, 40);
            }, "Name should not be empty or whitespace!");
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-10)]
        public void DamageSetterShouldThrowAnExceptionWhenIsZeroOrNegative(int damage)
        {
            //Act and Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Ivs", damage, 40);
            }, "Damage value should be positive!");
        }

        [TestCase(-1)]
        [TestCase(-10)]
        public void HPSetterShouldThrowAnExceptionWhenIsNegative(int hp)
        {
            //Act and Assert
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("Ivs", 50, hp);
            }, "HP should not be negative!");
        }

        [TestCase(70, 50)]
        [TestCase(60, 59)]
        [TestCase(60, 60)]
        public void AttackMethodShouldDecreaseAttackerHpWithWarriorDamage(int hp, int damage)
        {
            //Arrange
            Warrior warriorA = new Warrior("Attacker", 80, hp);
            Warrior warriorB = new Warrior("Defender", damage, 50);

            //Act
            warriorA.Attack(warriorB);

            int expectedHpA = hp - damage;
            int actualHpA = warriorA.HP;

            //Assert
            Assert.AreEqual(expectedHpA, actualHpA, "Access attack should decrease Attacker Hp");
        }

        [TestCase(70, 50)]
        [TestCase(60, 59)]
        [TestCase(60, 60)]
        public void AttackMethodShouldDecreaseDefenderHPToZero(int hp, int damage)
        {
            //Arrange
            Warrior warriorA = new Warrior("Attacker", 80, hp);
            Warrior warriorB = new Warrior("Defender", damage, 50);

            //Act
            warriorA.Attack(warriorB);

            int expectedHpB = 0;
            int actualHpB = warriorB.HP;

            //Assert
            Assert.AreEqual(expectedHpB, actualHpB, "Access attack should decrease Defender Hp to zero when Attacker Hp is greater than that");
        }

        [TestCase(60, 70)]
        [TestCase(60, 61)]
        public void AttackMethodShouldDecreaseDefenderHP(int damage, int hp)
        {
            //Arrange
            Warrior warriorA = new Warrior("Attacker", damage, 80);
            Warrior warriorB = new Warrior("Defender", 50, hp);

            //Act
            warriorA.Attack(warriorB);

            int expectedHpB = hp - damage;
            int actualHpB = warriorB.HP;

            //Assert
            Assert.AreEqual(expectedHpB, actualHpB, "Access attack should decrease Defender Hp whit Attacker Hp");
        }

        [TestCase(30, 30)]
        [TestCase(30, 29)]
        [TestCase(30, 1)]
        public void AttackMethodShouldThrowAnExceptionWhenAttackerHpIsLessThanMin(int minValue, int hp)
        {
            //Arrange
            Warrior warriorA = new Warrior("Attacker", 60, hp);
            Warrior warriorB = new Warrior("Defender", 50, 50);

            //Act and Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorA.Attack(warriorB);
            }, "Your HP is too low in order to attack other warriors!");
        }

        [TestCase(30, 30)]
        [TestCase(30, 29)]
        [TestCase(30, 1)]
        public void AttackMethodShouldThrowAnExceptionWhenDefenderHpIsLessThanMin(int minValue, int hp)
        {
            //Arrange
            Warrior warriorA = new Warrior("Attacker", 60, 50);
            Warrior warriorB = new Warrior("Defender", 50, hp);

            //Act and Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorA.Attack(warriorB);
            }, $"Enemy HP must be greater than {minValue} in order to attack him!");
        }

        [TestCase(40, 55)]
        [TestCase(58, 59)]
        [TestCase(31, 32)]
        public void AttackMethodShouldThrowAnExceptionWhenDefenderDamageIsBiggerThanAttackerHp(int hp, int damage)
        {
            //Arrange
            Warrior warriorA = new Warrior("Attacker", 60, hp);
            Warrior warriorB = new Warrior("Defender", damage, 60);

            //Act and Assert
            Assert.Throws<InvalidOperationException>(() =>
            {
                warriorA.Attack(warriorB);
            }, "You are trying to attack too strong enemy");
        }
    }
}