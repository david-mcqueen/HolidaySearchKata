using System;
using System.Collections.Generic;
using System.Text;

namespace HolidaySearcher.Search.SearchParameters
{
    public class FlightParameters: ISearchParameters
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
    }
}
