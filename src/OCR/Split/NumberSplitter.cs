namespace OCR.Split
{
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;

    public class NumberSplitter : ISplit
    {

        public IEnumerable<IEnumerable<string>> Split(string input)
        {
            return input
            .Lines()
            .Take(3)
            .Select(lines => lines.Partition(3))
            .Transpose();
        }
    }
}