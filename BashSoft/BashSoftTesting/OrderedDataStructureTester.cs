using NUnit.Framework;

namespace BashSoftTesting
{
    using BashSoft.DataStructures;
    using BashSoftTesting.Fakes;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class OrderedDataStructureTester
    {
        private ISimpleOrderedBag<string> sut;

        [TestFixtureSetUp]
        public void Setup()
        {
            this.sut = new SimpleSortedList<string>();
        }

        [Test]
        public void TestEmptyCtor()
        {
            this.sut = new SimpleSortedList<string>();

            Assert.AreEqual(this.sut.Capacity, 16);
            Assert.AreEqual(this.sut.Size, 0);
        }

        [Test]
        public void TestCtorWithInitialCapacity()
        {
            this.sut = new SimpleSortedList<string>(20);

            Assert.AreEqual(this.sut.Capacity, 20);
            Assert.AreEqual(this.sut.Size, 0);
        }

        [Test]
        public void TestCtorWithAllParams()
        {
            this.sut = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);

            Assert.AreEqual(this.sut.Capacity, 30);
            Assert.AreEqual(this.sut.Size, 0);
        }

        [Test]
        public void TestCtorWithInitialComparer()
        {
            this.sut = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);

            Assert.AreEqual(this.sut.Capacity, 16);
            Assert.AreEqual(this.sut.Size, 0);
        }

        [Test]
        public void TestAddIncreasesSize()
        {
            this.sut.Add("Nasko");

            Assert.AreEqual(1, this.sut.Size);
        }

        [Test]
        public void TestAddNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.sut.Add(null));
        }

        [Test]
        public void TestAddUnsortedDataIsHeldSorted()
        {
            var expectedCollection = new[] { "Balkan", "Georgi", "Rosen"
                , null, null, null, null, null, null, null, null, null, null, null, null, null, };
            var sut = new SimpleSortedListFake<string>();
            var elements = new[] { "Rosen", "Georgi", "Balkan" };

            foreach (var element in elements)
            {
                sut.Add(element);
            }

            CollectionAssert.AreEqual(expectedCollection, sut.ExposeCollection());
        }

        [Test]
        public void TestAddingMoreThanInitialCapacity()
        {
            sut = new SimpleSortedList<string>();
            var collection = new string[17];
            for (int i = 0; i < 17; i++)
            {
                collection[i] = "Ivan";
            }

            this.sut.AddAll(collection);

            Assert.AreEqual(17, sut.Size);
            Assert.AreNotEqual(16, sut.Capacity);
        }

        [Test]
        public void TestAddingAllFromCollectionIncreasesSize()
        {
            var collection = new List<string>() { "Rosen", "Georgi" };

            this.sut.AddAll(collection);

            Assert.AreEqual(2, this.sut.Size);
        }

        [Test]
        public void TestAddingAllFromNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.sut.AddAll(null));
        }

        [Test]
        public void TestAddAllKeepsSorted()
        {
            var expectedCollection = new[] { "Balkan", "Georgi", "Rosen"
                , null, null, null, null, null, null, null, null, null, null, null, null, null, };
            var sut = new SimpleSortedListFake<string>();
            var elements = new[] { "Rosen", "Georgi", "Balkan" };

            sut.AddAll(elements);

            CollectionAssert.AreEqual(expectedCollection, sut.ExposeCollection());
        }

        [Test]
        public void TestRemoveValidElementDecreasesSize()
        {
            var elements = new[] { "Rosen", "Georgi", "Balkan" };
            var sut = new SimpleSortedList<string>();
            sut.AddAll(elements);

            sut.Remove("Rosen");

            Assert.AreEqual(2, sut.Size);
        }

        [Test]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            var elements = new[] { "Ivan", "Nasko" };
            var sut = new SimpleSortedListFake<string>();
            sut.AddAll(elements);

            sut.Remove("Ivan");

            Assert.That(() => !sut.ExposeCollection().Contains("Ivan"));
        }

        [Test]
        public void TestRemovingNullThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => this.sut.Remove(null));
        }

        [Test]
        public void TestJoinWithNull()
        {
            var elements = new[] { "Ivan", "Nasko" };
            var sut = new SimpleSortedList<string>();
            sut.AddAll(elements);

            Assert.Throws<ArgumentNullException>(() => sut.JoinWith(null));
        }

        [Test]
        public void TestJoinWorksFine()
        {
            var joiner = ", ";
            var elements = new[] { "Ivan", "Nasko" };
            var expectedOutput = string.Join(joiner, elements);
            var sut = new SimpleSortedList<string>();
            sut.AddAll(elements);

            var stringResult = sut.JoinWith(joiner);

            Assert.AreEqual(expectedOutput, stringResult);
        }
    }
}