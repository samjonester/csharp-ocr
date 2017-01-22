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
            string input = "    _  _     _  _  _  _  _  _ \n" +
                           "  | _| _||_||_ |_   ||_||_|| |\n" +
                           "  ||_  _|  | _||_|  ||_| _||_|\n" +
                           "                              ";

            IEnumerable<int> output = Subject.Read(input);

            Assert.Equal(new List<int>{1,2,3,4,5,6,7,8,9,0}, output);
        }
    }
}
