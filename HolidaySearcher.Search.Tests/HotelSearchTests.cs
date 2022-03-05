using HolidaySearcher.Search.SearchParameters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidaySearcher.Search.Tests
{
    public class HotelSearchTests
    {
        private HotelSearch _hotelSearch { get; set; }

        [SetUp]
        public void Setup()
        {
            _hotelSearch = new HotelSearch();
        }


        private static readonly object[] _specificHotelTestData =
        {
            new object[] {"TFS", "2022-11-05", 7, new List<int> { 1, 2 } },
            new object[] {"PMI", "2023-06-15", 14, new List<int> { 3, 4 } },
            new object[] {"PMI", "2023-06-15", 10, new List<int> { 5, 13 } },
            new object[] {"LPA", "2022-11-10", 14, new List<int> { 6 } },
            new object[] {"LPA", "2022-09-10", 14, new List<int> { 7 } },
            new object[] {"LPA", "2022-10-10", 7, new List<int> { 8 } },
            new object[] {"AGP", "2023-07-01", 7, new List<int> { 9 } },
            new object[] {"AGP", "2023-07-01", 14, new List<int> { 12 } },
            new object[] {"AGP", "2023-07-05", 10, new List<int> { 10 } },
            new object[] {"AGP", "2023-10-16", 7, new List<int> { 11 } },
        };

        [Test]
        [TestCaseSource("_specificHotelTestData")]
        public void GivenSpecificHotelParameters_WhenSearchIsCalled_ThenTheCorrectHotelsAreReturned(string destinationAirport, string date, int duration, List<int> expectedMatchIds)
        {
            // Given
            var hParams = new HolidayParameters
            {
                Destination = destinationAirport,
                Duration = duration,
                DepartureDate = DateTime.Parse(date)
            };

            // When
            var hotels = _hotelSearch.Search(hParams);

            // Then
            Assert.That(hotels, Is.Not.Null);
            Assert.That(hotels.Count, Is.EqualTo(expectedMatchIds.Count));
            foreach (var id in expectedMatchIds)
            {
                Assert.That(hotels.Any(f => f.Id == id), Is.Not.Null);
            }
        }
    }
}
