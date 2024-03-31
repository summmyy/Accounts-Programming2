//this class depends of the implementation of the following types:
//DayTime struct and AccountType enum
public static class Utils
{
    private static DayTime _time = new DayTime(1_048_000_000);
    private static Random random = new Random();
    public static DayTime Time
    {
        get => _time += random.Next(1000);
    }
    public static DayTime Now
    {
        get => _time += 0;
    }
    public readonly static Dictionary<AccountType, string> ACCOUNT_TYPES =
    new Dictionary<AccountType, string>
    {
        { AccountType.Checking , "CK-" },
        { AccountType.Saving , "SV-" },
        { AccountType.Visa , "VS-" }
    };
}
