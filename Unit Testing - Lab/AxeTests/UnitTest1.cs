using NUnit.Framework;

namespace Skeleton.Tests
{
    using System;

    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void DurabilityAfterAttack_ShouldDecrease()
        {
            //Arrange
            Axe axe = new Axe(5, 5);
            Dummy dummy = new Dummy(5, 5);

            //Act
            axe.Attack(dummy);

            //Asset
            Assert.AreEqual(4, axe.DurabilityPoints);
        }

        [Test]
        public void AttackWithBrokenWeapon_ShouldThrowException()
        {
            //Arrange
            Axe axe = new Axe(2, 0);
            Dummy dummy = new Dummy(2, 2);

            //Act


            //Asset
            Assert.Throws<InvalidOperationException>(() =>
            {
                axe.Attack(dummy);

            }, "Axe is broken.");
        }
    }
}