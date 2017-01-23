namespace OCR.Account
{
    using System.Linq;
    using Convert;
    public class AccountPrinter : IPrintAccount
    {
        public string Print(AccountValue account) {
            string numberAsString = string.Join("", account.Number.Select(n => n != NumberConverter.INVALID ? n.ToString() : "?"));
            string illOrErr = "";
            if (account.Number.Contains(NumberConverter.INVALID)) {
                illOrErr = " ILL";
            }
            else if (!account.Valid)
            {
                illOrErr = " ERR";
            }
            return $"{numberAsString}{illOrErr}";
        }
    }
}