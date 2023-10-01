namespace TimeLib
{
    public readonly partial struct TimePeriod : IComparable<TimePeriod>
    {
        public int CompareTo(TimePeriod other)
        {
            if (this.Seconds - other.Seconds < 0) return -1;
            else if (this.Seconds - other.Seconds < 0) return 0;
            else return 1;
        }

        public static bool operator <(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(TimePeriod left, TimePeriod right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}
