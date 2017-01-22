namespace OCRTest.SplitTest {
    using Xunit;
    using OCR.Split;
    using System.Collections.Generic;
    using System.Linq;

    public class NumberSplitterTest {

        private ISplit Subject;

        public NumberSplitterTest() {
            Subject = new NumberSplitter();
        }

        [Fact]
        public void itShouldSplitABlockOfNumbers() {
            string input = "    _ \n" +
                           "  | _|\n" +
                           "  ||_ \n" +
                           "      ";
            List<IEnumerable<string>> output = new List<IEnumerable<string>> {
                new List<string> {
                    "   ",
                    "  |",
                    "  |"
                },
                new List<string> {
                    " _ ",
                    " _|",
                    "|_ "
                }
            };

            Assert.True(
                Subject.Split(input)
                .Zip(output, (x, y) => x.SequenceEqual(y))
                .All(x => x)
            );
        }
    }
}