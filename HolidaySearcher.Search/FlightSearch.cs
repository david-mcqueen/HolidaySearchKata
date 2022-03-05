using HolidaySearcher.Repository;
using HolidaySearcher.Repository.Components;
using HolidaySearcher.Search.SearchParameters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HolidaySearcher.Search
{
    public class FlightSearch : ISearch
    {
        private Repository<Flight> _flights { get; set; }
        private List<string> _londonAirports { get; set; } = new List<string> { "LGW", "LTN" };

        public FlightSearch()
        {
            _flights = new Repository<Flight>();
        }
        public IList<IHolidayComponent> Search(ISearchParameters parameters)
        {
            var flightParams = parameters as FlightParameters;

            return _flights.GetData()
                .Where(f => isValidDeparture(f, flightParams.Departure)
                        && isValidDestination(f, flightParams.Destination)
                        && isValidDate(f, flightParams.Date))
                .OrderBy(f => f.Price)
                .ToList<IHolidayComponent>();
        }

        private bool isValidDeparture(Flight f, string departure)
        {
            if (departure.Equals("ANY"))
            {
                return true;
            }

            if (departure.Equals("ANY LONDON"))
            {
                return _londonAirports.Contains(f.Departure);
            }

            return f.Departure.Equals(departure);
        }

        private bool isValidDate(Flight f, DateTime date)
        {
            return f.DepartureDate == date;
        }

        private bool isValidDestination(Flight f, string destination)
        {
            return f.Destination == destination;
        }
    }
}
