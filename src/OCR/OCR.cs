namespace OCR
{
    using System.Linq;
    using System.Collections.Generic;
    using static Extensions.ObjectExtensions;
    using Convert;
    using Split;
    using CheckSum;

    public class OCR
    {
        private ISplit Splitter;
        private IConvert Converter;

        private ICheckSum CheckSummer;

        public OCR() : this(new NumberSplitter(), new NumberConverter(), new CheckSummer()) {}

        public OCR(ISplit splitter, IConvert converter, ICheckSum checksummer) {
            this.Splitter = splitter;
            this.Converter = converter;
            this.CheckSummer = checksummer;
        }

        public Account Read(string input) {
            return Splitter.Split(input)
            .Select(Converter.Convert)
            .With(accountNumber => new Account {
                    Number = string.Join("", accountNumber),
                    Checksum = CheckSummer.CheckSum(accountNumber)
            });
        }
    }
}
