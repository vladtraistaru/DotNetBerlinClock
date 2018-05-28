using BerlinClock.Classes.Models;
using System;
using System.Linq;
using System.Text;

namespace BerlinClock.Classes
{
    public class BerlinClockBuilder : IBerlinClockBuilder
    {
        public string BuildBerlinClockRepresentation(Time Time)
        {
            var berlinClock = new StringBuilder();
            berlinClock.AppendLine(BuildFirstLine(Time));
            berlinClock.AppendLine(BuildFirstHoursLine(Time));
            berlinClock.AppendLine(BuildSecondHoursLine(Time));
            berlinClock.AppendLine(BuildFirstMinutesLine(Time));
            berlinClock.Append(BuildSecondMinutesLine(Time));
            return berlinClock.ToString();
        }
        private string BuildFirstLine(Time date)
        {
            return (date.Second % 2 == 0) ? Constants.Strings.LightIndicators.Yellow.ToString() : Constants.Strings.LightIndicators.Off.ToString();
        }

        private string BuildFirstHoursLine(Time date)
        {
            var noOfRedLights = (int)Math.Floor(date.Hour / 5.0);

            return string.Format("{0}{1}",
                new string(Enumerable.Repeat(Constants.Strings.LightIndicators.Red, noOfRedLights).ToArray()),
                new string(Enumerable.Repeat(Constants.Strings.LightIndicators.Off, Constants.Ints.NoOfLightsFirstLine - noOfRedLights).ToArray()));
        }

        private string BuildSecondHoursLine(Time date)
        {
            var noOfRedLights = (int)Math.Floor(date.Hour % 5.0);

            return string.Format("{0}{1}",
                new string(Enumerable.Repeat(Constants.Strings.LightIndicators.Red, noOfRedLights).ToArray()),
                new string(Enumerable.Repeat(Constants.Strings.LightIndicators.Off, Constants.Ints.NoOfLightsSecondLine - noOfRedLights).ToArray()));

        }

        private string BuildFirstMinutesLine(Time date)
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

        private string BuildSecondMinutesLine(Time date)
        {
            var noOfLights = (int)Math.Floor(date.Minute % 5.0);

            return string.Format("{0}{1}",
                new string(Enumerable.Repeat(Constants.Strings.LightIndicators.Yellow, noOfLights).ToArray()),
                new string(Enumerable.Repeat(Constants.Strings.LightIndicators.Off, Constants.Ints.NoOfLightsForthLine - noOfLights).ToArray()));
        }
    }
}
