using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerlinClock.Classes
{
    public class BerlinClockBuilder : IBerlinClockBuilder
    {
        public string BuildBerlinClockRepresentation(DateTime dateTime)
        {
            var berlinClock = new StringBuilder();
            berlinClock.AppendLine(BuildFirstLine(dateTime));
            berlinClock.AppendLine(BuildFirstHoursLine(dateTime));
            berlinClock.AppendLine(BuildSecondHoursLine(dateTime));
            berlinClock.AppendLine(BuildFirstMinutesLine(dateTime));
            berlinClock.AppendLine(BuildSecondMinutesLine(dateTime));
            return berlinClock.ToString();
        }
        private string BuildFirstLine(DateTime date)
        {
            return (date.Second % 2 == 0) ? Constants.Strings.LightIndicators.Yellow.ToString() : Constants.Strings.LightIndicators.Off.ToString();
        }

        private string BuildFirstHoursLine(DateTime date)
        {
            var noOfRedLights = (int)Math.Floor(date.Hour / 5.0);
            return string.Format("{0}{1}",
                new string(Enumerable.Repeat(Constants.Strings.LightIndicators.Red, noOfRedLights).ToArray()),
                new string(Enumerable.Repeat(Constants.Strings.LightIndicators.Red, Constants.Ints.NoOfLightsFirstLine - noOfRedLights).ToArray()));
        }

        private string BuildSecondHoursLine(DateTime date)
        {
            return string.Empty;
        }

        private string BuildFirstMinutesLine(DateTime date)
        {
            return string.Empty;
        }

        private string BuildSecondMinutesLine(DateTime date)
        {
            return string.Empty;
        }
    }
}
