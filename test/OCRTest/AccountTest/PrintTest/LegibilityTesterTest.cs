namespace OCRTest.AccountTest.PrintTest
{
    using Xunit;
    using System.Collections.Generic;
    using OCR.Account.Print;
    using OCR.FP;
    public class LegibilityTesterTest
    {
        ITestLegibility Subject;

        public LegibilityTesterTest() {
            Subject = new LegibilityTester();
        }

        [Fact]
        public void itShouldUnwrapIfAllJust() {
            IEnumerable<Maybe<int>> input = new List<Maybe<int>> {Maybe<int>.Just(1), Maybe<int>.Just(2), Maybe<int>.Just(3)};
            IEnumerable<int> desiredOutput = new List<int> {1, 2, 3};

            IEnumerable<int> output = Subject.TestLegibility(input).FromRight();

            Assert.Equal(desiredOutput, output);
        }

        [Fact]
        public void itShouldErrorIfHasNothing() {
            IEnumerable<Maybe<int>> input = new List<Maybe<int>> {Maybe<int>.Just(1), Maybe<int>.Nothing(), Maybe<int>.Just(3)};

            string output = Subject.TestLegibility(input).FromLeft();

            Assert.Equal("1?3 ILL", output);
        }
    }
}