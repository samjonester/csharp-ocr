namespace OCR.Split {
    using System.Collections.Generic;
    public interface ISplit {
        IEnumerable<IEnumerable<string>> Split(string input);
    }
}