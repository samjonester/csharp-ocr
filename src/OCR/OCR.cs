namespace OCR
{
    using System.Linq;
    using static Extensions.ObjectExtensions;
    using Convert;
    using Split;
    using CheckSum;
    using Account;

    public class OCR
    {
        private ISplit Splitter;
        private IConvert Converter;

        private ICheckSum CheckSummer;

        private IPrintAccount Printer;

        public OCR() : this(new NumberSplitter(), new NumberConverter(), new CheckSummer(), new AccountPrinter()) {}

        public OCR(ISplit splitter, IConvert converter, ICheckSum checksummer, IPrintAccount printer) {
            this.Splitter = splitter;
            this.Converter = converter;
            this.CheckSummer = checksummer;
            this.Printer = printer;
        }

        public AccountValue Read(string input) {
            return Splitter.Split(input)
            .Select(Converter.Convert)
            .With(accountNumber => new AccountValue {
                Number = accountNumber,
                Checksum = CheckSummer.CheckSum(accountNumber)
            })
            .With(account => {
                account.PrintedValue = Printer.Print(account);
                return account;
            });
        }
    }
}
