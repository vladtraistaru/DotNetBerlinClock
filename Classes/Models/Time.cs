using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes.Models
{
    public class Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public static Time Parse(string aTime)
        {
            var splits = aTime.Split(':');
            if(splits.Length != 3)
            {
                throw new ArgumentException("Argument 'aTime' has incorrect representation. Correct : HH:mm:ss");
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

            if (hours > 24)
            {
                throw new ArgumentException("Maximum hours value is 24");
            }
            if (minutes > 59)
            {
                throw new ArgumentException("Maximum minutes value is 59");
            }
            if (seconds > 59)
            {
                throw new ArgumentException("Maximum seconds value is 59");
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
