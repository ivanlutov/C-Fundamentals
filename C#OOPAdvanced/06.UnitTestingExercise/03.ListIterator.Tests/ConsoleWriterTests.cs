using System;
using System.IO;
using _03.IteratorTest.Contracts;
using Moq;
using NUnit.Framework;
using _03.IteratorTest.Models;

namespace _03.ListIterator.Tests
{
    [TestFixture]
    public class ConsoleWriterTests
    {
        [Test]
        public void ShouldWriteAnyMessageAtConsole()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            var console = new ConsoleWriter();
            console.WriteLine("Pesho");

            Assert.AreEqual("Pesho\r\n", writer.ToString());
        }
    }
}