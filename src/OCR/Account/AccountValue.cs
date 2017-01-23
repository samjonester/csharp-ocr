namespace OCR
{
    using System.Collections.Generic;
    public class AccountValue
    {
        public IEnumerable<int> Number {get; set;}
        public string PrintedValue {get; set;}

        public int Checksum {get; set;}

        public bool Valid{
            get {
                return this.Checksum == 0;
            }
        }
    }
}