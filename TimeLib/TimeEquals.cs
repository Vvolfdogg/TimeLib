namespace TimeLib
{
    public readonly partial struct Time : IEquatable<Time>
    {
        public bool Equals(Time other)
        {
            return this.Hours == other.Hours && this.Minutes == other.Minutes && this.Seconds == other.Seconds;
        }

        public bool Equals(object? obj)
        {
            if (obj is null) return false;
            if(obj is Time other) return Equals(other);
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }

        public static bool operator ==(Time left, Time right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Time left, Time right)
        {
            return !(left == right);
        }

    }
}
