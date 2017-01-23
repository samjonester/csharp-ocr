namespace OCRTest.CheckSumTest {
    using Xunit;
    using System.Collections.Generic;
    using System.Linq;
    using OCR.CheckSum;
    using OCR.FP;
    public class CheckSummerTest {
        private ICheckSum Subject;

        public CheckSummerTest() {
            Subject = new CheckSummer();
        }

        [Theory,
        InlineData(new int[] {3,4,5,8,8,2,8,6,5}, 0),
        InlineData(new int[] {3}, 3),
        InlineData(new int[] {1,3}, 5)
        ]
        public void itShouldCheckSum(int[] accountNumber, int expectedChecksum) {
            // account number: 3 4 5 8 8 2 8 6 5 position names: d9 d8 d7 d6 d5 d4 d3 d2 d1
            //
            // (d1+2*d2+3*d3 +..+9*d9) mod 11 = 0

            IEnumerable<int> input = new List<int>(accountNumber);
            Assert.Equal(expectedChecksum, Subject.CheckSum(input));
        }
    }
}