using System;

namespace OCR.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {

        private OCR subject;

        [SetUp]
        public void Setup() {
            subject = new OCR();
        }

        [Test]
        public void itShouldReadInput()
        {
            string input = "  _  _     _  _  _  _  _ \n" +
                           "| _| _||_||_ |_   ||_||_|\n" +
                           "||_  _|  | _||_|  ||_| _|\n" +
                           "                         ";

            double output = subject.read(input);

            Assert.AreEqual(123456789, output);
        }
    }
}
