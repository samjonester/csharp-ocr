namespace OCR.Account.Print
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using FP;
    public class LegibilityTester : ITestLegibility
    {
        public Either<string, IEnumerable<int>> TestLegibility(IEnumerable<Maybe<int>> accountNumber) {
            return accountNumber
            .Select(m => Either<char, int>.FromMaybe(m, '?'))
            .LiftToEither(n => n.ToString().ToCharArray()[0])
            .SelectLeft(error => new String(error.ToArray()) + " ILL");
        }


    }
}