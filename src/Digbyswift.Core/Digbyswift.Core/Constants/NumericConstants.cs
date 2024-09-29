namespace Digbyswift.Core.Constants;

public static class NumericConstants
{
    public const int Zero = 0;
    public const int One = 1;
    public const int Two = 2;
    public const int Three = 3;
    public const int Ten = 10;
    public const int Hundred = 100;
    public const int Thousand = 1000;

    public static class Milliseconds
    {
        public const int PerSecond = Thousand;
        public const int PerMinute = PerSecond * Seconds.PerMinute;
        public const int PerHour = PerMinute * Minutes.PerHour;
        public const int PerDay = PerHour * Hours.PerDay;
        public const int PerWeek = PerDay * 7;
        public const int PerFortnight = PerWeek * Two;
    }

    public static class Seconds
    {
        public const int PerMinute = 60;
        public const int PerHour = PerMinute * Minutes.PerHour;
        public const int PerDay = PerHour * Hours.PerDay;
        public const int PerWeek = PerDay * 7;
        public const int PerFortnight = PerWeek * Two;
    }

    public static class Minutes
    {
        public const int PerHour = 60;
        public const int PerDay = PerHour * Hours.PerDay;
        public const int PerWeek = PerDay * 7;
        public const int PerFortnight = PerWeek * Two;
    }

    public static class Hours
    {
        public const int PerDay = 24;
        public const int PerWeek = PerDay * 7;
        public const int PerFortnight = PerWeek * Two;
    }
}
