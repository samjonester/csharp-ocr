namespace OCR.Split {
    using System.Collections.Generic;
    public interface ISplit {
        List<string> Split(string input);
    }
}