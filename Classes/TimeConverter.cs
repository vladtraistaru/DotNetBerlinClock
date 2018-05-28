using BerlinClock.Classes;
using BerlinClock.Classes.Models;
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
            var time = Time.Parse(aTime);

            var clock = BerlinClock.Classes.BerlinClock.FromTime(time);
            return clock.TimeStr;
        }        
    }
}
