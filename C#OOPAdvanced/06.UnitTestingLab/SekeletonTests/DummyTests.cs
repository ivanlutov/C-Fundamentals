using Moq;
using NUnit.Framework;
using Skeleton.Contracts;
using System;

namespace SekeletonTests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyShouldLosesHealthIfAttacked()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(20, 20);

            axe.Attack(dummy);

            Assert.AreEqual(10, dummy.Health);
        }

        [Test]
        public void ShouldThrowExceptionIfAttackedDummyIsDead()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(0, 20);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }

        [Test]
        public void IfDummyDiesInAttackShouldGiveExperienceToHero()
        {
            var axeStub = new Mock<IWeapon>();
            axeStub.SetupGet(x => x.AttackPoints).Returns(10);
            axeStub.SetupGet(x => x.DurabilityPoints).Returns(10);
            var dummyStub = new Mock<ITarget>();
            dummyStub.SetupGet(x => x.Health).Returns(5);
            dummyStub.Setup(x => x.GiveExperience()).Returns(5);
            dummyStub.Setup(x => x.IsDead()).Returns(true);
            Hero hero = new Hero("Ivan", axeStub.Object);

            hero.Attack(dummyStub.Object);

            Assert.AreEqual(5, hero.Experience);
        }

        [Test]
        public void IfDummyAttackedButNotDieDontGiveExperience()
        {
            var axeStub = new Mock<IWeapon>();
            axeStub.SetupGet(x => x.AttackPoints).Returns(10);
            axeStub.SetupGet(x => x.DurabilityPoints).Returns(10);
            var dummyStub = new Mock<ITarget>();
            dummyStub.Setup(x => x.GiveExperience()).Returns(5);
            dummyStub.Setup(x => x.IsDead()).Returns(false);
            Hero hero = new Hero("Ivan", axeStub.Object);

            hero.Attack(dummyStub.Object);

            Assert.AreEqual(0, hero.Experience);
        }
    }
}