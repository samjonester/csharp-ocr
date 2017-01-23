namespace OCR.Account.Print
{
    using System.Collections.Generic;
    using FP;
    using CheckSum;
    using Extensions;
    public class Validator : IValidate
    {
        private ICheckSum CheckSummer;

        public Validator() : this(new CheckSummer()) {}
        public Validator(ICheckSum checkSummer) {
            this.CheckSummer = checkSummer;
        }
        public Either<string, IEnumerable<int>> Validate(IEnumerable<int> accountNumber)
        {
            if (CheckSummer.CheckSum(accountNumber) == 0) {
                return Either<string, IEnumerable<int>>.Right(accountNumber);
            } else {
                return Either<string, IEnumerable<int>>.Left(accountNumber.StrJoin() + " ERR");
            }
        }

    }
}