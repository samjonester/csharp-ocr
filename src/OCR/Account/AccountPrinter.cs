namespace OCR.Account
{
    public class AccountPrinter : IPrintAccount
    {
        public string Print(AccountValue account) {
            return string.Join("", account.Number) +
            (account.Valid ? "" : " ERR");
        }
    }
}