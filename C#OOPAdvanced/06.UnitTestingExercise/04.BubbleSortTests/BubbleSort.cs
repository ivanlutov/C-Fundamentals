using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.BubbleSort.Models;
namespace _04.BubbleSortTests
{
    [TestFixture]
    public class BubbleSort
    {
        [Test]
        public void ShouldMustSortCollectionOfInts()
        {
            var testCollection = new List<int> { 100, 23, 123, 12, 2, 3, };
            var sorter = new Bubble();

            sorter.Sort(testCollection);

            CollectionAssert.AreEqual(new List<int> { 2, 3, 12, 23, 100, 123 }, testCollection);
        }
    }
}
