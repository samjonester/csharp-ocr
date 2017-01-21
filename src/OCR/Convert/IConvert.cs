namespace OCR.Convert
{
    using System.Collections.Generic;
    public interface IConvert
    {
       double Convert(IEnumerable<IEnumerable<string>> numbers);
    }
}