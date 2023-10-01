namespace TimeLib
{
    public readonly partial struct TimePeriod : IEquatable<TimePeriod>
    {
        public bool Equals(TimePeriod other)
        {
            return this.Seconds == other.Seconds;
        }

        public bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (obj is TimePeriod other) return Equals(other);
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Seconds);
        }

        public static bool operator ==(TimePeriod left, TimePeriod right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TimePeriod left, TimePeriod right)
        {
            return !(left == right);
        }
    }
}
