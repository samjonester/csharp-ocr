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
            Subject = new OCR();
            string input = " _     _  _  _  _  _  _  _ \n" +
                           " _||_||_ |_||_| _||_||_ |_ \n" +
                           " _|  | _||_||_||_ |_||_| _|\n" +
                           "                           ";

            AccountValue output = Subject.Read(input);

            Assert.Equal("345882865", output.PrintedValue);
        }
 
        [Fact]
        public void invalidAccount()
        {
            Subject = new OCR();
            string input = " _     _  _  _  _  _  _  _ \n" +
                           "|_||_||_ |_||_| _||_||_ |_ \n" +
                           "|_|  | _||_||_||_ |_||_| _|\n" +
                           "                           ";

            AccountValue output = Subject.Read(input);

            Assert.Equal("845882865 ERR", output.PrintedValue);
        }
    }
}
