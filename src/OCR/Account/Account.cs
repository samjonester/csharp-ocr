namespace OCR
{
    public class Account
    {
        public string Number {get; set;}

        public int Checksum {get; set;}

        public bool Valid{
            get {
                return this.Checksum == 0;
            }
        }
    }
}