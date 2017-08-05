using System;

namespace _03.ListIterator.Tests
{
    using IteratorTest.Models;
    using Moq;
    using NUnit.Framework;
    using IteratorTest.Contracts;

    [TestFixture]
    public class TestsListIterator
    {
        [Test]
        public void ListIteratorSuccessfullyCreatedIfAcceptListOfStringsInCtor()
        {
            var writerMock = new Mock<IWriter>();
            var strings = new[] {"Ivan", "Pesho", "Gosho"};
            var iterator = new ListIterator(writerMock.Object, strings);

            Assert.AreEqual(3, iterator.Count());
        }

        [Test]
        public void ListIteratorThrowExceptionIfNotAcceptAnyParametersInCtor()
        {
            var writerMock = new Mock<IWriter>();

            Assert.Throws<ArgumentNullException>(() => new ListIterator(writerMock.Object));
        }

        [Test]
        public void MoveShouldReturnTrueIfThereIsNextIndex()
        {
            var writerMock = new Mock<IWriter>();
            var strings = new[] {"Ivan", "Pesho", "Gosho"};
            var iterator = new ListIterator(writerMock.Object, strings);

            Assert.IsTrue(iterator.Move());
        }

        [Test]
        public void MoveShouldReturnFalseIfThereIsNoNextIndex()
        {
            var writerMock = new Mock<IWriter>();
            var strings = new[] {"Ivan", "Pesho", "Gosho"};
            var iterator = new ListIterator(writerMock.Object, strings);

            iterator.Move();
            iterator.Move();

            Assert.IsFalse(iterator.Move());
        }

        [Test]
        public void HasNextShouldReturnTrueIfThereIsAnythingOnTheNextIndex()
        {
            var writerMock = new Mock<IWriter>();
            var strings = new[] {"Ivan", "Pesho", "Gosho"};
            var iterator = new ListIterator(writerMock.Object, strings);

            Assert.IsTrue(iterator.HasNext());
        }

        [Test]
        public void HasNextShouldReturnFalseIfThereIsNothingOnTheNextIndex()
        {
            var writerMock = new Mock<IWriter>();
            var strings = new[] {"Ivan"};
            var iterator = new ListIterator(writerMock.Object, strings);

            Assert.IsFalse(iterator.HasNext());
        }
    }
}
