namespace OCR.Account.Print
{
    using System.Collections.Generic;
    using FP;
    public interface IValidate
    {
        Either<string, IEnumerable<int>> Validate(IEnumerable<int> accountNumber);
    }
}