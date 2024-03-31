public struct DayTime{
    private long minutes;
    public DayTime(long minutes){
        this.minutes = minutes;
    }

    public static DayTime operator +(DayTime lhs, int minutes){
        return new DayTime(lhs.minutes + minutes);
    }
    public override string ToString()
    {
        double year, month, day, hour, min;
        year = (double)minutes / 518400;
        month = (year - Math.Floor(year)) * 12;
        day = (month - Math.Floor(month)) * 31 ;
        hour = (day - Math.Floor(day)) * 24 ;
        min = (hour - Math.Floor(hour) ) * 60; 
        return $"{(int)year}-{(int)month:d2}-{(int)day:d2} {(int)hour:d2}:{(int)min:d2}";
    }
}