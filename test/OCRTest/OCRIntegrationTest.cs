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
        public void validAccount()
        {
            Subject = new OCR();
            string input = " _     _  _  _  _  _  _  _ \n" +
                           " _||_||_ |_||_| _||_||_ |_ \n" +
                           " _|  | _||_||_||_ |_||_| _|\n" +
                           "                           ";

            Account output = Subject.Read(input);

            Assert.Equal(output.Number, "345882865");
            Assert.True(output.Valid);
        }
 
        [Fact]
        public void invalidAccount()
        {
            Subject = new OCR();
            string input = " _     _  _  _  _  _  _  _ \n" +
                           "|_||_||_ |_||_| _||_||_ |_ \n" +
                           "|_|  | _||_||_||_ |_||_| _|\n" +
                           "                           ";

            Account output = Subject.Read(input);

            Assert.Equal(output.Number, "845882865");
            Assert.False(output.Valid);
        }
    }
}
