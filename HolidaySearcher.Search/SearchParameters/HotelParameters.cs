using System;
using System.Collections.Generic;
using System.Text;

namespace HolidaySearcher.Search.SearchParameters
{
    public class HotelParameters : ISearchParameters
    {
        public int Duration { get; set; }
        public string Destination { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}
