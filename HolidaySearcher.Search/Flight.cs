using System;

namespace HolidaySearcher.Search
{
    public class Flight
    {
        public int Id { get; set; }
        public string Airline { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public decimal Price { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
