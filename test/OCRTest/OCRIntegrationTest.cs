using System;

namespace OCR.Test
{
    using Xunit;

    public class OCRIntegrationTest
    {

        private OCR Subject;
        public OCRIntegrationTest() {
            Subject = new OCR();
        }

        [Fact]
        public void validAccount()
        {
            string input = " _     _  _  _  _  _  _  _ \n" +
                           " _||_||_ |_||_| _||_||_ |_ \n" +
                           " _|  | _||_||_||_ |_||_| _|\n" +
                           "                           ";

            Assert.Equal("345882865", Subject.Read(input));
        }
 
        [Fact]
        public void invalidAccount()
        {
            string input = " _     _  _  _  _  _  _  _ \n" +
                           "|_||_||_ |_||_| _||_||_ |_ \n" +
                           "|_|  | _||_||_||_ |_||_| _|\n" +
                           "                           ";

            Assert.Equal("845882865 ERR", Subject.Read(input));
        }

        [Fact]
        public void illegalAccount()
        {
            string input = " _  _        _        _  _ \n" +
                           "|_||_   |  || | _||_| _||_ \n" +
                           "|_||_|  |  ||_||   _  _| _|\n" +
                           "                           ";


            Assert.Equal("86110??35 ILL", Subject.Read(input));
        }
    }
}
