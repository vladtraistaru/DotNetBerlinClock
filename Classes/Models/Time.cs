using System;

namespace BerlinClock.Classes.Models
{
    public class Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as Time;

            if (item == null)
            {
                return false;
            }

            return this.Hour == item.Hour && this.Minute == item.Minute && this.Second == item.Second;
        }

        public override int GetHashCode()
        {
            return this.Hour.GetHashCode() * 17 + this.Minute.GetHashCode() * 19 + this.Second.GetHashCode() * 23;
        }

        public static Time Parse(string aTime)
        {
            var splits = aTime.Split(':');
            if(splits.Length != 3)
            {
                throw new ArgumentException("Argument 'aTime' has incorrect number of delimiters. Correct : HH:mm:ss");
            }

            var hours = 0;
            var minutes = 0;
            var seconds = 0;
            if(!int.TryParse(splits[0], out hours)
                || !int.TryParse(splits[1], out minutes)
                || !int.TryParse(splits[2], out seconds))
            {
                throw new ArgumentException("Cannot convert to int");
            }

            if (hours > 24 || hours < 0)
            {
                throw new ArgumentException("Hours out of bounds. Interval is 0-24.");
            }
            if (minutes > 59 || minutes < 0)
            {
                throw new ArgumentException("Minutes out of bounds. Interval is 0-59.");
            }
            if (seconds > 59 || seconds < 0)
            {
                throw new ArgumentException("Seconds out of bounds. Interval is 0-59.");
            }

            return new Time()
            {
                Hour = hours,
                Minute = minutes,
                Second = seconds
            };
        }
    }
}
