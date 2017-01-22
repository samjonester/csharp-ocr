namespace OCR.CheckSum {
    using System.Collections.Generic;
    public interface ICheckSum {
        int CheckSum(IEnumerable<int> number);
    }
}