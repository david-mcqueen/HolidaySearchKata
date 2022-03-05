using HolidaySearcher.Repository.Components;
using HolidaySearcher.Search.SearchParameters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HolidaySearcher.Search
{
    public class HolidaySearch
    {
        private FlightSearch _flightSearch { get; set; }
        private HotelSearch _hotelSearch { get; set; }
        public HolidaySearch()
        {
            _flightSearch = new FlightSearch();
            _hotelSearch = new HotelSearch();
        }

        public Holiday Search(HolidayParameters parameters)
        {
            var flights = _flightSearch.Search(parameters);
            var hotels = _hotelSearch.Search(parameters);

            return new Holiday
            {
                Flight = flights.First() as Flight,
                Hotel = hotels.First() as Hotel
            };
        }
    }
}
