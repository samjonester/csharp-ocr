namespace OCRTest.ExtensionsTest
{
    using Xunit;
    using System.Collections.Generic;
    using OCR.Extensions;

    public class StringExtensionTest
    {
       [Fact]
       public void itShouldChunkString() {
           string input = "111222333";
           List<string> output = new List<string> {"111", "222", "333"};

           Assert.Equal(output, input.Partition(3));
        }

        [Fact]
        public void itShouldSplitString() {
            Assert.Equal(new List<string> {"abc", "def"}, "abc\ndef".Lines());

            Assert.Equal(new List<string> {"abc"}, "abc".Lines());
        }
    }
}