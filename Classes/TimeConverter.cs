using BerlinClock.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        public string convertTime(string aTime)
        {
            var dateTime = DateTime.ParseExact(aTime, "HH:mm:ss", CultureInfo.InvariantCulture);

            var clock = BerlinClock.Classes.BerlinClock.FromDateTime(dateTime);
            return clock.TimeStr;
        }        
    }
}
