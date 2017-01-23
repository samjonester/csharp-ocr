namespace OCR.CheckSum {
    using System.Collections.Generic;
    using FP;
    public interface ICheckSum {
        int CheckSum(IEnumerable<int> number);
    }
}