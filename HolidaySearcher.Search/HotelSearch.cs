using HolidaySearcher.Repository;
using HolidaySearcher.Repository.Components;
using HolidaySearcher.Search.SearchParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidaySearcher.Search
{
    public class HotelSearch : ISearch
    {
        private Repository<Hotel> _hotels{ get; set; }

        public HotelSearch()
        {
            _hotels = new Repository<Hotel>();
        }
        public IList<IHolidayComponent> Search(ISearchParameters parameters)
        {
            var hotelParams = parameters as HotelParameters;

            return _hotels.GetData()
                .Where(h => isValidDate(h, hotelParams.ArrivalDate)
                        && isValidDuration(h, hotelParams.Duration)
                        && isServicedByAirport(h, hotelParams.Destination))
                .ToList<IHolidayComponent>();
        }

        private bool isValidDate(Hotel h, DateTime date)
        {
            return h.ArrivalDate == date;
        }

        private bool isValidDuration(Hotel h, int duration)
        {
            return h.Nights == duration;
        }

        private bool isServicedByAirport(Hotel h, string destination)
        {
            return h.LocalAirports.Contains(destination);
        }
    }
}
