namespace OCR.Account
{
    using System.Collections.Generic;
    using FP;
    public interface IPrintAccount
    {
         string Print(IEnumerable<Maybe<int>> accountNumber);
    }
}