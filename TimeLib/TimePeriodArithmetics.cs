namespace TimeLib
{
    public readonly partial struct TimePeriod
    {
        public static TimePeriod operator +(TimePeriod tp1, TimePeriod tp2)
        {
            return new (tp1.Seconds + tp2.Seconds);
        }

        public static TimePeriod operator -(TimePeriod tp1, TimePeriod tp2)
        {
            long minus = tp1.Seconds - tp2.Seconds;
            if (minus < 0) return new(0);
            return new(minus);
        }

        public static TimePeriod operator ++(TimePeriod tp)
        {
            return new(tp.Seconds + 3600);
        }

        public static TimePeriod operator --(TimePeriod tp)
        {
            if (tp.Seconds < 3600) return new(0);
            return new(tp.Seconds - 3600);
        }

        public static TimePeriod operator *(TimePeriod tp, int number)
        {
            return new(tp.Seconds * number);
        }

        public static TimePeriod operator /(TimePeriod tp, int number)
        {
            return new(tp.Seconds / number);
        }

        public TimePeriod Plus(TimePeriod tp) => new(this.Seconds + tp.Seconds);
        public TimePeriod Minus(TimePeriod tp) => new(this.Seconds - tp.Seconds);
    }
}
