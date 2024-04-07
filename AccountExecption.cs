public class AccountException : Exception
{
    public AccountException(ExceptionType message) : base(message.ToString()){}
}