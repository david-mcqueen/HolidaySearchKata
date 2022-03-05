using HolidaySearcher.Repository.Components;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HolidaySearcher.Repository
{
    public class FlightRepository : IRepository
    {
        private IList<Flight> _flights { get; set; }

        public FlightRepository()
        {
            JArray flightData = JArray.Parse(File.ReadAllText(@"DataSource/flights.json"));
            _flights = flightData.ToObject<IList<Flight>>();
        }

        public IHolidayComponent GetAvailableComponent()
        {
            return _flights.First();
        }
    }
}
