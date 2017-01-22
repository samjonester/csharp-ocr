namespace OCRTest.ExtensionsTest
{
    using Xunit;
    using System.Collections.Generic;
    using OCR.Extensions;

    public class ObjectExtensionsTest
    {
        [Fact]
        public void itShouldDoSomethingWithAClass() {

        }

        [Fact]
        public void itShouldDoSomethingWithAList() {
            var input = new List<int>{1,2,3};

            Assert.Equal("123", input.With(list => string.Join("", list)));
        }
    }
}