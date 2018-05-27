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
            berlinClock.Append(BuildSecondMinutesLine(dateTime));
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
                new string(Enumerable.Repeat(Constants.Strings.LightIndicators.Off, Constants.Ints.NoOfLightsFirstLine - noOfRedLights).ToArray()));
        }

        private string BuildSecondHoursLine(DateTime date)
        {
            var noOfRedLights = (int)Math.Floor(date.Hour % 5.0);

            return string.Format("{0}{1}",
                new string(Enumerable.Repeat(Constants.Strings.LightIndicators.Red, noOfRedLights).ToArray()),
                new string(Enumerable.Repeat(Constants.Strings.LightIndicators.Off, Constants.Ints.NoOfLightsSecondLine - noOfRedLights).ToArray()));

        }

        private string BuildFirstMinutesLine(DateTime date)
        {
            var noOfOpenedLights = (int)Math.Floor(date.Minute / 5.0);

            var openedLights = new StringBuilder();
            for (int i = 1; i <= noOfOpenedLights; i++)
            {
                if(i%3 == 0)
                {
                    openedLights.Append(Constants.Strings.LightIndicators.Red);
                }
                else
                {
                    openedLights.Append(Constants.Strings.LightIndicators.Yellow);
                }
            }           

            return string.Format("{0}{1}", openedLights.ToString(),
                new string(Enumerable.Repeat(Constants.Strings.LightIndicators.Off, Constants.Ints.NoOfLightsThirdLine - openedLights.Length).ToArray()));
        }

        private string BuildSecondMinutesLine(DateTime date)
        {
            var noOfLights = (int)Math.Floor(date.Minute % 5.0);

            return string.Format("{0}{1}",
                new string(Enumerable.Repeat(Constants.Strings.LightIndicators.Yellow, noOfLights).ToArray()),
                new string(Enumerable.Repeat(Constants.Strings.LightIndicators.Off, Constants.Ints.NoOfLightsForthLine - noOfLights).ToArray()));
        }
    }
}
