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
        private Repository<Hotel> _hotels { get; set; }

        public HotelSearch()
        {
            _hotels = new Repository<Hotel>();
        }

        public IList<IHolidayComponent> Search(HolidayParameters holidayParams)
        {
            return _hotels.GetData()
                .Where(h => isValidDate(h, holidayParams.Date)
                        && isValidDuration(h, holidayParams.Duration)
                        && isServicedByAirport(h, holidayParams.Destination))
                .OrderBy(h => h.PricePerNight)
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
