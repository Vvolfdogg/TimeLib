namespace TimeLib
{
    public readonly partial struct Time : IComparable<Time>
    {
        public int CompareTo(Time other)
        {
            if(this.Hours < other.Hours) return -1;
            else if(this.Hours > other.Hours) return 1;
            else
            {
                if(this.Minutes < other.Minutes) return -1;
                else if(other.Minutes > this.Minutes) return 1;
                else
                {
                    if(this.Seconds < other.Seconds) return -1;
                    else if(this.Seconds > other.Seconds) return 1;
                    else return 0;
                }
            }
        }

        public static bool operator <(Time left, Time right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Time left, Time right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(Time left, Time right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Time left, Time right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}
