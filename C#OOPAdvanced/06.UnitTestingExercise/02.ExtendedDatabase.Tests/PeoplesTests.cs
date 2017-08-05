using _02.ExtendedDatabase.Models;
using NUnit.Framework;

namespace _02.ExtendedDatabase.Tests
{
    [TestFixture]
    public class PeoplesTests
    {
        [Test]
        public void PeoplesCtorShouldAcceptNameAndId()
        {
            var people = new People("Ivan", 0);

            Assert.AreEqual("Ivan", people.Name);
            Assert.AreEqual(0, people.Id);
        }
    }
}