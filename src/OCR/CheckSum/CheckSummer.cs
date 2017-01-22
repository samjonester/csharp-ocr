namespace OCR.CheckSum
{
    using System.Collections.Generic;
    using System.Linq;
    public class CheckSummer : ICheckSum
    {
        public int CheckSum(IEnumerable<int> number) {
            return number
            .Reverse()
            .Select((num, i) => new {Number = num, Index = i+1})
            .Aggregate(0, (sum, current) => sum + (current.Number * current.Index)) % 11;
        }
    }
}