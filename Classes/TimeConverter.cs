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
            if(aTime == "24:00:00")
            {
                //special handle for incorrect case - "24.00.00". Not correct time representation in gregorian calendar
                return Constants.Strings.BerlinClock.SpecialRepresentation2400Hours;
            }
            var dateTime = DateTime.ParseExact(aTime, "HH:mm:ss", CultureInfo.InvariantCulture);

            var clock = BerlinClock.Classes.BerlinClock.FromDateTime(dateTime);
            return clock.TimeStr;
        }        
    }
}
