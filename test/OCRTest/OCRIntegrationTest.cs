using System;

namespace OCR.Test
{
    using Xunit;
    using Moq;
    using System.Collections.Generic;
    using Convert;
    using Split;

    public class OCRIntegrationTest
    {

        private OCR Subject;
        public OCRIntegrationTest() {
            Subject = new OCR();
        }

        [Fact]
        public void integrationTest()
        {
            Subject = new OCR();
            string input = "  _  _     _  _  _  _  _ \n" +
                           "| _| _||_||_ |_   ||_||_|\n" +
                           "||_  _|  | _||_|  ||_| _|\n" +
                           "                         ";

            double output = Subject.Read(input);

            Assert.Equal(123456789, output);
        }
    }
}
