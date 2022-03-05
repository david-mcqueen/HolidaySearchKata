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
            var fParams = new FlightParameters
            {
                Date = parameters.DepartureDate,
                Departure = parameters.Departure,
                Destination = parameters.Destination
            };

            var hParams = new HotelParameters
            {
                Destination = parameters.Destination,
                ArrivalDate = parameters.DepartureDate,
                Duration = parameters.Duration
            };

            var flights = _flightSearch.Search(fParams);
            var hotels = _hotelSearch.Search(hParams);

            return new Holiday
            {
                Flight = flights.First() as Flight,
                Hotel = hotels.First() as Hotel
            };
        }
    }
}
