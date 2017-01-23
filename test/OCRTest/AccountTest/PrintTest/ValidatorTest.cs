namespace OCRTest.AccountTest.PrintTest
{
    using Xunit;
    using System.Collections.Generic;
    using Moq;
    using OCR.Account.Print;
    using OCR.CheckSum;
    using OCR.FP;
    public class ValidatorTest
    {
        IValidate Subject;
        Mock<ICheckSum> CheckSummer;

        public ValidatorTest() {
            CheckSummer = new Mock<ICheckSum>();
            Subject = new Validator(CheckSummer.Object);
        }

        [Fact]
        public void itShouldPassThroughWithZero() {
            IEnumerable<int> input = new List<int>{1,2,3};
            int validChecksum = 0;
            CheckSummer.Setup(cs => cs.CheckSum(input)).Returns(validChecksum);

            IEnumerable<int> output = Subject.Validate(input).FromRight();

            Assert.Equal(input, output);
        }

        [Fact]
        public void itShouldErrorWithNonZero() {
            IEnumerable<int> input = new List<int>{1,2,3};
            int invalidChecksum = 5;
            CheckSummer.Setup(cs => cs.CheckSum(input)).Returns(invalidChecksum);

            string output = Subject.Validate(input).FromLeft();

            Assert.Equal("123 ERR", output);
        }
    }
}