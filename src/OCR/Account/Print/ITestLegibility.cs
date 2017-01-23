namespace OCR.Account.Print
{
    using System.Collections.Generic;
    using System.Linq;
    using FP;
    public interface ITestLegibility
    {
        Either<string, IEnumerable<int>> TestLegibility(IEnumerable<Maybe<int>> accountNumber);
    }
}