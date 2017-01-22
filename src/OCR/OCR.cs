namespace OCR
{
    using Convert;
    using Split;
    using System.Collections.Generic;
    using System.Linq;

    public class OCR
    {
        private ISplit Splitter;
        private IConvert Converter;

        public OCR() : this(new NumberSplitter(), new NumberConverter()) {}

        public OCR(ISplit splitter, IConvert converter) {
            this.Splitter = splitter;
            this.Converter = converter;
        }

        public IEnumerable<int> Read(string input) {
            return Splitter.Split(input)
            .Select(splitInput => Converter.Convert(splitInput));
        }
    }
}
