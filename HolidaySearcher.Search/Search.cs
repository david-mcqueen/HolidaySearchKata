using System;

namespace HolidaySearcher.Search
{
    public interface ISearch
    {
        Holiday SearchHoliday(string depart, string destination, string departureDate, int duration);
    }

    public class Search : ISearch
    {
        public Holiday SearchHoliday(string depart, string destination, string departureDate, int duration)
        {
            throw new NotImplementedException();
        }
    }
}
