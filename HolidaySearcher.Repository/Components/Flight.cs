using Newtonsoft.Json;
using System;

namespace HolidaySearcher.Repository.Components
{
    public class Flight: IHolidayComponent
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("airline")]
        public string Airline { get; set; }

        [JsonProperty("from")]
        public string Departure { get; set; }

        [JsonProperty("to")]
        public string Destination { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("departure_date")]
        public DateTime DepartureDate { get; set; }
    }
}
