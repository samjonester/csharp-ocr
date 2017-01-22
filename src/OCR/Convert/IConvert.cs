namespace OCR.Convert
{
    using System.Collections.Generic;
    public interface IConvert
    {
       int Convert(IEnumerable<string> number);
    }
}