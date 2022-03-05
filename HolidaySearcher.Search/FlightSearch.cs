using HolidaySearcher.Repository;
using HolidaySearcher.Repository.Components;
using HolidaySearcher.Search.SearchParameters;
using System.Collections.Generic;
using System.Linq;

namespace HolidaySearcher.Search
{
    public class FlightSearch : ISearch
    {
        private Repository<Flight> _flights { get; set; }
        public FlightSearch()
        {
            _flights = new Repository<Flight>();
        }
        public IList<IHolidayComponent> Search(ISearchParameters parameters)
        {
            var flightParams = parameters as FlightParameters;

            return _flights.GetData()
                .Where(f => f.Departure == flightParams.Departure
                        && f.Destination == flightParams.Destination
                        && f.DepartureDate == flightParams.Date)
                .ToList<IHolidayComponent>();
        }
    }
}
