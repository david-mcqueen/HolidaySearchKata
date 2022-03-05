using System;
using System.Collections.Generic;
using System.Text;

namespace HolidaySearcher.Search.SearchParameters
{
    public class HolidayParameters
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public int Duration { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
