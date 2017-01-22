namespace OCRTest.CheckSumTest {
    using Xunit;
    using System.Collections.Generic;
    using OCR.CheckSum;
    public class CheckSummerTest {
        private ICheckSum Subject;

        public CheckSummerTest() {
            Subject = new CheckSummer();
        }

        [Fact]
        public void itShouldCheckSum() {
            // account number: 3 4 5 8 8 2 8 6 5 position names: d9 d8 d7 d6 d5 d4 d3 d2 d1
            //
            // (d1+2*d2+3*d3 +..+9*d9) mod 11 = 0

            Assert.Equal(0, Subject.CheckSum(new List<int> {3,4,5,8,8,2,8,6,5}));

            Assert.Equal(3, Subject.CheckSum(new List<int> {3}));
            Assert.Equal(5, Subject.CheckSum(new List<int> {1,3}));
        }
    }
}