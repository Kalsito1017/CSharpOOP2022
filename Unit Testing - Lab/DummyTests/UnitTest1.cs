using NUnit.Framework;

namespace Skeleton.Tests
{
    using System;

    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void HealthAfterAttack_ShouldDecrease()
        {
            //Arrange
            Dummy dummy = new Dummy(5, 2);

            //Act
            dummy.TakeAttack(4);

            //Assert
            Assert.AreEqual(1, dummy.Health);
        }

        [Test]
        public void AttackWithDeadDummy_ShouldThrowException()
        {
            //Arrange
            Dummy dummy = new Dummy(0, 0);

            //Act

            //Asset
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(1);

            }, "Dummy is dead.");
        }

        [Test]
        public void DeadDummy_ShouldGiveXP()
        {
            //Arrange
            Dummy dummy = new Dummy(0, 1);

            //Act

            //Asset
            Assert.AreEqual(1, dummy.GiveExperience());
        }

        [Test]
        public void AliveDummy_ShouldNotGiveXP()
        {
            //Arrange
            Dummy dummy = new Dummy(5, 1);

            //Act

            //Asset
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();

            }, "Target is not dead.");

            //Assert.That(()=>dummy.GiveExperience(), Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}