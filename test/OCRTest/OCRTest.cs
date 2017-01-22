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
            string input = "hello world";

            List<string> numberStrings = new List<string> {"so long", "and thanks", "for all the fish"};
            List<List<string>> splitOutput = new List<List<string>> {numberStrings};
            int convertedNumber = 42;


            Splitter.Setup(numberSplitter => numberSplitter.Split(input)).Returns(splitOutput);
            Converter.Setup(numberConverter => numberConverter.Convert(numberStrings)).Returns(convertedNumber);

            IEnumerable<int> output = Subject.Read(input);

            Assert.Equal(new List<int>{convertedNumber}, output);
        }
    }
}
