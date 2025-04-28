public class DateHelper
{
    public static string[] days = { "lundi", "mardi", "mercredi", "jeudi", "vendredi", "samedi", "dimanche" };
    public static string[] months = { "janvier", "fevrier", "mars", "avril", "mai", "juin", "juillet", "aout", "septembre", "octobre", "novembre", "decembre" };
    public static int baseYear = 2010;

    public const int yearvalue = 364;
    public const int monthvalue = 31;
    public const int dayvalue = 7;

    public static Date GetDate(int timer)
    {
        Date date = new Date();

        int rest = timer;

        int year = baseYear + rest / yearvalue;
        rest %= yearvalue;

        int month = rest % monthvalue;

        int day = rest % dayvalue;

        date.day = days[day];
        date.dayID = day;
        date.month = months[month];
        date.monthID = month;
        date.year = year;

        return date;
    }
}

public class Date
{
    public string day;
    public string month;
    public int dayID;
    public int monthID;
    public int year;
}