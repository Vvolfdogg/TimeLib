namespace TimeLib
{
    public readonly partial struct TimePeriod
    {
        public long Seconds { get; init; }
        public string Period { get; init; }

        #region presets
        public static readonly TimePeriod Day = new(86400);
        public static readonly TimePeriod Hour = new(3600);
        public static readonly TimePeriod Quarter = new(900);
        public static readonly TimePeriod Minute = new(60);
        public static readonly TimePeriod Second = new(1);
        #endregion

        public TimePeriod(long seconds)
        {
            if (seconds < 0) throw new Exception("Wrong syntax");
            Seconds = seconds;
            Period = $"{seconds / 3600}:{(seconds - (seconds / 3600) * 3600) / 60}:{seconds % 60}";
        }

        public TimePeriod(byte hours = 0, byte minutes = 0, byte seconds = 0)
        {
            if (seconds < 0 || minutes < 0 || hours < 0) throw new Exception("Wrong syntax");
            Seconds = hours * 3600 + minutes * 60 + seconds;
            Period = $"{Seconds / 3600}:{(Seconds - (Seconds / 3600) * 3600) / 60}:{Seconds % 60}";
        }

        public TimePeriod(byte hours, byte minutes) 
        {
            if (minutes < 0 || hours < 0) throw new Exception("Wrong syntax");
            Seconds = hours * 3600 + minutes * 60;
            Period = $"{Seconds / 3600}:{(Seconds - (Seconds / 3600) * 3600) / 60}:00";
        }

        public TimePeriod(Time t1, Time t2)
        {
            int hours = Math.Abs(t2.Hours - t1.Hours);
            int minutes = Math.Abs(t2.Minutes - t1.Minutes);
            int seconds = Math.Abs(t2.Seconds - t1.Seconds);

            Seconds = hours * 3600 + minutes * 60 + seconds;
            Period = $"{hours}:{minutes}:{seconds}";
        }

        public TimePeriod(string time)
        {
            var tab = time.Split(":");
            bool success = false;
            int hours;
            int minutes;
            int seconds;

            if (tab.Length == 1)
            {
                success = Int32.TryParse(time, out hours);
                minutes = 0;
                seconds = 0;
                time += ":00:00";
            }
            else if (tab.Length == 2)
            {
                success = Int32.TryParse(tab[0], out hours);
                success = Int32.TryParse(tab[1], out minutes);
                seconds = 0;
                time += ":00";
            }
            else if (tab.Length == 3)
            {
                success = Int32.TryParse(tab[0], out hours);
                success = Int32.TryParse(tab[1], out minutes);
                success = Int32.TryParse(tab[2], out seconds);
            }
            else
                throw new Exception("Wrong syntax");

            if (success)
            {
                if ( hours < 0 || minutes < 0 || seconds < 0) throw new Exception("Wrong syntax");

                Seconds = hours * 3600 + minutes * 60 + seconds;
                Period = time;
            }
            else throw new Exception("Wrong syntax");
        }

        public override string? ToString() {
            var tab = Period.Split(":");
            if(tab[1].Length == 1) tab[1] = "0" + tab[1];
            if(tab[2].Length == 1) tab[2] = "0" + tab[2];

            return tab[0] + ":" + tab[1] + ":" + tab[2];
        }

    }
}