namespace OCR.Convert
{
    using System.Collections.Generic;
    using FP;
    public interface IConvert
    {
       Maybe<int> Convert(IEnumerable<string> number);
    }
}