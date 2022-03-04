﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HolidaySearcher.Search
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ArrivalDate { get; set; }
        public decimal PricePerNight { get; set; }
        public List<string> LocalAirports { get; set; }
        public int Nights { get; set; }
    }
}
