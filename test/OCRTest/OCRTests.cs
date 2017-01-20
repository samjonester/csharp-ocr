using System;

namespace OCR.Tests
{
    using Xunit;

    public class Tests
    {

        private OCR subject;

        public Tests() {
            subject = new OCR();
        }

        [Fact]
        public void itShouldReadInput()
        {
            string input = "  _  _     _  _  _  _  _ \n" +
                           "| _| _||_||_ |_   ||_||_|\n" +
                           "||_  _|  | _||_|  ||_| _|\n" +
                           "                         ";

            double output = subject.read(input);

            Assert.Equal(123456789, output);
        }
    }
}
