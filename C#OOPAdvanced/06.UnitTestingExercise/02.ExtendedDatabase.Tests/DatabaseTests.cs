using _02.ExtendedDatabase.Contracts;
using _02.ExtendedDatabase.Models;
using Moq;
using NUnit.Framework;
using System;

namespace _02.ExtendedDatabase.Tests
{
    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void TheDatabaseMustBeEmptyWhenCreated()
        {
            var db = new Database();

            Assert.AreEqual(0, db.Count());
        }

        [Test]
        public void DatabaseShouldAddSinglePerson()
        {
            var personStub = new Mock<IPeople>();
            var db = new Database();

            db.Add(personStub.Object);

            Assert.AreEqual(1, db.Count());
        }

        [Test]
        public void DatabaseShouldAddManyPersons()
        {
            var firstPersonStub = new Mock<IPeople>();
            firstPersonStub.SetupGet(p => p.Name).Returns("Ivan");
            firstPersonStub.SetupGet(p => p.Id).Returns(0);
            var secondPersonStub = new Mock<IPeople>();
            secondPersonStub.SetupGet(p => p.Name).Returns("Pesho");
            secondPersonStub.SetupGet(p => p.Id).Returns(1);
            var thirdPersonStub = new Mock<IPeople>();
            thirdPersonStub.SetupGet(p => p.Name).Returns("Gosho");
            thirdPersonStub.SetupGet(p => p.Id).Returns(2);
            var db = new Database();

            db.Add(firstPersonStub.Object);
            db.Add(secondPersonStub.Object);
            db.Add(thirdPersonStub.Object);

            Assert.AreEqual(3, db.Count());
        }

        [Test]
        public void IfAddUserWithNameWhichAlreadyExistInDatabaseThrowException()
        {
            var firstPersonStub = new Mock<IPeople>();
            firstPersonStub.SetupGet(p => p.Name).Returns("Ivan");
            var secondPersonStub = new Mock<IPeople>();
            secondPersonStub.SetupGet(p => p.Name).Returns("Ivan");
            var db = new Database();
            db.Add(firstPersonStub.Object);

            Assert.Throws<InvalidOperationException>(() => db.Add(secondPersonStub.Object));
        }

        [Test]
        public void IfAddUserWithIdWhichAlreadyExistInDatabaseThrowException()
        {
            var firstPersonStub = new Mock<IPeople>();
            firstPersonStub.SetupGet(p => p.Id).Returns(0);
            var secondPersonStub = new Mock<IPeople>();
            secondPersonStub.SetupGet(p => p.Id).Returns(0);
            var db = new Database();
            db.Add(firstPersonStub.Object);

            Assert.Throws<InvalidOperationException>(() => db.Add(secondPersonStub.Object));
        }

        [Test]
        public void RemoveSinglePersonFromDatabase()
        {
            var personStub = new Mock<IPeople>();
            var db = new Database();

            db.Add(personStub.Object);
            db.Remove();

            Assert.AreEqual(0, db.Count());
        }

        [Test]
        public void RemoveCommandShouldRemoveTheLastPersonFromDatabase()
        {
            var firstPersonStub = new Mock<IPeople>();
            firstPersonStub.SetupGet(p => p.Name).Returns("Pesho");
            firstPersonStub.SetupGet(p => p.Id).Returns(0);
            var secondPersonStub = new Mock<IPeople>();
            secondPersonStub.SetupGet(p => p.Name).Returns("Ivan");
            secondPersonStub.SetupGet(p => p.Id).Returns(1);

            var db = new Database();

            db.Add(firstPersonStub.Object);
            db.Add(secondPersonStub.Object);
            var persenForCompare = db.Remove();

            Assert.AreEqual("Ivan", persenForCompare.Name);
        }

        [Test]
        public void RemoveShouldThrowExceptionIfDatabaseIsEmpty()
        {
            var db = new Database();

            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void FindByUserNameShouldReturnPerson()
        {
            var personStub = new Mock<IPeople>();
            personStub.SetupGet(p => p.Name).Returns("Ivan");
            var db = new Database();

            db.Add(personStub.Object);
            var personForCompare = db.FindByUsername("Ivan");

            Assert.AreEqual("Ivan", personForCompare.Name);
        }

        [Test]
        public void FindByIdShouldReturnPerson()
        {
            var personStub = new Mock<IPeople>();
            personStub.SetupGet(p => p.Id).Returns(0);
            var db = new Database();

            db.Add(personStub.Object);
            var personForCompare = db.FindById(0);

            Assert.AreEqual(0, personForCompare.Id);
        }

        [Test]
        public void FindByNameShouldThrowExceptionIfDatabaseNotConstainsUserWithThisName()
        {
            var personStub = new Mock<IPeople>();
            personStub.SetupGet(p => p.Name).Returns("Ivan");
            var db = new Database();

            db.Add(personStub.Object);

            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("Gosho"));
        }

        [Test]
        public void FindByNameShouldThrowExceptionIfUsernameParameterIsNull()
        {
            var personStub = new Mock<IPeople>();
            personStub.SetupGet(p => p.Name).Returns("Ivan");
            var db = new Database();

            db.Add(personStub.Object);

            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(null));
        }

        [Test]
        public void FindByIdShouldThrowExceptionIfDatabaseNotConstainsUserWithThisId()
        {
            var personStub = new Mock<IPeople>();
            personStub.SetupGet(p => p.Id).Returns(0);
            var db = new Database();

            db.Add(personStub.Object);

            Assert.Throws<InvalidOperationException>(() => db.FindById(1));
        }

        [Test]
        public void FindByIdShouldThrowExceptionIfIdParameterIsNegative()
        {
            var personStub = new Mock<IPeople>();
            personStub.SetupGet(p => p.Id).Returns(0);
            var db = new Database();

            db.Add(personStub.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-1));
        }
    }
}