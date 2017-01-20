using System;

namespace OCR.Test
{
    using Xunit;
    using Moq;
    using System.Collections.Generic;
    using Convert;
    using Split;

    public class OCRTest
    {

        private OCR Subject;
        private Mock<ISplit> Splitter;
        private Mock<IConvert> Converter;

        public OCRTest() {
            Splitter = new Mock<ISplit>();
            Converter = new Mock<IConvert>();
            Subject = new OCR(Splitter.Object, Converter.Object);
        }

        [Fact]
        public void itShouldReadAndConvertNumber() {
            string input = "  _  _     _  _  _  _  _ \n" +
                           "| _| _||_||_ |_   ||_||_|\n" +
                           "||_  _|  | _||_|  ||_| _|\n" +
                           "                         ";
            List<string> splitOutput = new List<string> {"foo", "bar"};
            double convertedOutput = 123123123;

            Splitter.Setup(numberSplitter => numberSplitter.Split(input)).Returns(splitOutput);
            Converter.Setup(numberConverter => numberConverter.Convert(splitOutput)).Returns(convertedOutput);

            double output = Subject.Read(input);

            Assert.Equal(convertedOutput, output);
        }
    }
}
