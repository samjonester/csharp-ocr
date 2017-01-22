namespace OCRTest.ExtensionsTest
{
    using Xunit;
    using System.Collections.Generic;
    using System.Linq;
    using OCR.Extensions;

    public class ListExtensionsTest
    {
       [Fact]
       public void itShouldTranspose() {
           List<List<int>> input = new List<List<int>> {
               new List<int> {1, 2, 3},
               new List<int> {4, 5, 6}
           };
           List<List<int>> output = new List<List<int>> {
               new List<int> {1, 4},
               new List<int> {2, 5},
               new List<int> {3, 6}
           };

            Assert.True(
                input.Transpose()
                .Zip(output, (x, y) => x.SequenceEqual(y))
                .All(x => x)
            );
       }
    }
}