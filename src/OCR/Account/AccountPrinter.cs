namespace OCR.Account
{
    using System.Collections.Generic;
    using Extensions;
    using FP;
    using CheckSum;
    using Print;
    public class AccountPrinter : IPrintAccount
    {
        private ICheckSum CheckSummer;
        private ITestLegibility LegibilityTester;
        private IValidate Validator;

        public AccountPrinter() : this(new LegibilityTester(), new Validator()) {}

        public AccountPrinter(ITestLegibility legibilityTester, IValidate validator) {
            this.LegibilityTester = legibilityTester;
            this.Validator = validator;
        }

        public string Print(IEnumerable<Maybe<int>> accountNumber) {
            return accountNumber
            .With(LegibilityTester.TestLegibility)
            .Chain(Validator.Validate)
            .Case(
                error => error,
                right => right.StrJoin()
            );
        }

    }
}