using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public class BerlinClock
    {
        public string TimeStr { get; private set; }
        public DateTime Time { get; private set; }               

        public static BerlinClock FromDateTime(DateTime time)
        {
            var builder = new BerlinClockBuilder();
            var result = builder.BuildBerlinClockRepresentation(time);

            var clock = new BerlinClock()
            {
                Time = time,
                TimeStr = result
            };
            return clock;
        }
    }
}
