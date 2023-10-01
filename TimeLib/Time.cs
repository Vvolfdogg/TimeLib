namespace TimeLib
{
    public readonly partial struct Time
    {
        public byte Hours { get; init; }
        public byte Minutes { get; init; }
        public byte Seconds { get; init; }

        #region presets
        public static readonly Time Noon = new(12);
        public static readonly Time Midnight = new();
        #endregion

        public Time(byte hours = 0, byte minutes = 0, byte seconds = 0)
        {
            if (hours >= 24 || minutes >= 60 || seconds >= 60) throw new Exception("Wrong syntax");

            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public Time(string time)
        {
            var tab = time.Split(":");
            bool success = false;
            byte hours;
            byte minutes;
            byte seconds;

            if (tab.Length == 1)
            {
                success = Byte.TryParse(time, out hours);
                minutes = 0;
                seconds = 0;
            }
            else if (tab.Length == 2)
            {
                success = Byte.TryParse(tab[0], out hours);
                success = Byte.TryParse(tab[1], out minutes);
                seconds = 0;
            }
            else if (tab.Length == 3)
            {
                success = Byte.TryParse(tab[0], out hours);
                success = Byte.TryParse(tab[1], out minutes);
                success = Byte.TryParse(tab[2], out seconds);
            }
            else
                throw new Exception("Wrong syntax");

            if (success)
            {
                if (hours >= 24 || minutes >= 60 || seconds >= 60) throw new Exception("Wrong syntax");

                Hours = hours;
                Minutes = minutes;
                Seconds = seconds;
            }
            else throw new Exception("Wrong syntax");
        }

        public static Time Parse(string time)
        {
            return new Time(time);
        }

        public override string ToString()
        {
            string toString;

            if (Hours < 10) toString = "0" + Hours;
            else toString = Hours.ToString();

            if (Minutes < 10) toString += ":0" + Minutes;
            else toString += ":" + Minutes;

            if (Seconds < 10) toString += ":0" + Seconds;
            else toString += ":" + Seconds;

            return toString;
        }
    }
}