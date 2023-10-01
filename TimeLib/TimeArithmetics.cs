namespace TimeLib
{
    public readonly partial struct Time
    {

        public Time Plus(TimePeriod tp)
        {
            long tSec = this.Hours * 3600 + this.Minutes * 60 + this.Seconds;
            long sec = tSec + tp.Seconds;

            byte hours = (byte)(int)((sec / 3600) % 24);
            byte minutes = (byte)(int)((sec - (sec / 3600) * 3600) / 60);
            byte seconds = (byte)(int)(sec % 60);

            return new Time(hours, minutes, seconds);
        }

        public Time Minus(TimePeriod tp)
        {
            long tSec = this.Hours * 3600 + this.Minutes * 60 + this.Seconds;

            if(tSec < tp.Seconds)
            {
                for(int i = 0; i <= tp.Seconds / 86400; i++)
                {
                    tSec += 86400;
                }
            }
            long sec = tSec - tp.Seconds;

            byte hours = (byte)(int)((sec / 3600) % 24);
            byte minutes = (byte)(int)((sec - (sec / 3600) * 3600) / 60);
            byte seconds = (byte)(int)(sec % 60);

            return new Time(hours, minutes, seconds);
        }
    }
}
