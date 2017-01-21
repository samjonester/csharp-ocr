namespace OCR
{
    using System.Collections.Generic;
    using Convert;
    using Split;
    public class OCR
    {
        private ISplit Splitter;
        private IConvert Converter;

        public OCR() : this(new NumberSplitter(), new NumberConverter()) {}

        public OCR(ISplit splitter, IConvert converter) {
            this.Splitter = splitter;
            this.Converter = converter;
        }

        public double Read(string input) {
            IEnumerable<IEnumerable<string>> splitInput = Splitter.Split(input);
            double numbers = Converter.Convert(splitInput);
            return numbers;
        }
    }
}
