using BerlinClock.Classes.Models;

namespace BerlinClock.Classes
{
    public interface IBerlinClockBuilder
    {
        string BuildBerlinClockRepresentation(Time dateTime);
    }
}
