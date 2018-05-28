using BerlinClock.Classes.Models;
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
        public Time Time { get; private set; }

        public static BerlinClock FromTime(Time time)
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
