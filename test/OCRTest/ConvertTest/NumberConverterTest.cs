namespace OCRTest.ConverterTest {
    using Xunit;
    using System.Collections.Generic;
    using OCR.Convert;
    public class NumberConverterTest {
        IConvert Subject;
        public NumberConverterTest() {
            Subject = new NumberConverter();
        }

        [Fact]
        public void itShouldConvert1() {
            List<string> zero = new List<string> {"   ",
                                                  "  |",
                                                  "  |"};

            Assert.Equal(1, Subject.Convert(zero));
        }
        [Fact]
        public void itShouldConvert2() {
            List<string> two = new List<string> { " _ ",
                                                  " _|",
                                                  "|_ " };

            Assert.Equal(2, Subject.Convert(two));
        }
        [Fact]
        public void itShouldConvert3() {
            List<string> three = new List<string> { " _ ",
                                                    " _|",
                                                    " _|" };

            Assert.Equal(3, Subject.Convert(three));
        }
        [Fact]
        public void itShouldConvert4() {
            List<string> four = new List<string> { "   ",
                                                   "|_|",
                                                   "  |" };

            Assert.Equal(4, Subject.Convert(four));
        }
        [Fact]
        public void itShouldConvert5() {
            List<string> five = new List<string> { " _ ",
                                                   "|_ ",
                                                   " _|" };

            Assert.Equal(5, Subject.Convert(five));
        }
        [Fact]
        public void itShouldConvert6() {
            List<string> six = new List<string> { " _ ",
                                                  "|_ ",
                                                  "|_|" };

            Assert.Equal(6, Subject.Convert(six));
        }

        [Fact]
        public void itShouldConvert7() {
            List<string> seven = new List<string> { " _ ",
                                                    "  |",
                                                    "  |" };
            Assert.Equal(7, Subject.Convert(seven));
        }

        [Fact]
        public void itShouldConvert8() {
            List<string> eight = new List<string> {" _ ",
                                                   "|_|",
                                                   "|_|"};

            Assert.Equal(8, Subject.Convert(eight));
        }

        [Fact]
        public void itShouldConvert9() {
                List<string> nine = new List<string> {" _ ",
                                                      "|_|",
                                                      " _|"};

            Assert.Equal(9, Subject.Convert(nine));
        }

        [Fact]
        public void itShouldConvert0() {
            List<string> zero = new List<string> { " _ ",
                                                   "| |",
                                                   "|_|" };

            Assert.Equal(0, Subject.Convert(zero));
        }
    }
}