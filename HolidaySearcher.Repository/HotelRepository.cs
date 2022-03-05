using HolidaySearcher.Repository.Components;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HolidaySearcher.Repository
{
    public class HotelRepository : IRepository
    {
        private IList<Hotel> _hotels { get; set; }

        public HotelRepository()
        {
            JArray hotelData = JArray.Parse(File.ReadAllText(@"DataSource/hotels.json"));
            _hotels = hotelData.ToObject<IList<Hotel>>();
        }

        public IHolidayComponent GetAvailableComponent()
        {
            return _hotels.First();
        }
    }
}
