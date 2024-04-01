struct DayTime{
    private long Minutes;

    public DayTime(long minutes){
        Minutes = minutes;
    }

    public static DayTime operator +(DayTime lhs, int minutes)
    {
        return new DayTime(lhs.Minutes + minutes);
    }

    public override string ToString()
    {
        int year = (int)(Minutes / (60 * 24 * 365));
        int month = (int)((Minutes % (60 * 24 * 365)) / (60 * 24 * 30));
        int day = (int)(((Minutes % (60 * 24 * 365)) % (60 * 24 * 30)) / (60 * 24));
        int hour = (int)((((Minutes % (60 * 24 * 365)) % (60 * 24 * 30)) % (60 * 24)) / 60);
        int remainingMinutes = (int)((((Minutes % (60 * 24 * 365)) % (60 * 24 * 30)) % (60 * 24)) % 60);

        return $"{year} years, {month} months, {day} days, {hour} hours, {remainingMinutes} minutes";
    }
}