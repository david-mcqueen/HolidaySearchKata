using NUnit.Framework;
using HolidaySearcher.Search;
using HolidaySearcher.Search.SearchParameters;
using System;

namespace HolidaySearcher.Search.Tests
{
    public class SampleTests
    {
        [Test]
        [TestCase("MAN", "AGP", "2023-07-01", 7, 2, 9)]
        [TestCase("ANY LONDON", "PMI", "2023-06-15", 10, 6, 5)]
        [TestCase("ANY", "LPA", "2022-11-10", 14, 7, 6)]
        public void GivenSampleTestCases_WhenSearchIsCalled_ThenTheBestHolidayIsReturned(string depart, string destination, string departureDate, int duration, int expectedFlightId, int expectedHotelId)
        {
            // Given
            var holidaySearch = new HolidaySearch();
            var holidayParams = new HolidayParameters
            {
                Departure = depart,
                Destination = destination,
                Date = DateTime.Parse(departureDate),
                Duration = duration
            };
            // When
            var bestHoliday = holidaySearch.Search(holidayParams);

            // Then
            Assert.That(bestHoliday, Is.Not.Null);

            // Verify the flight information
            Assert.That(bestHoliday.Flight, Is.Not.Null);
            Assert.That(bestHoliday.Flight.Id, Is.EqualTo(expectedFlightId));

            // Verify the hotel information
            Assert.That(bestHoliday.Hotel, Is.Not.Null);
            Assert.That(bestHoliday.Hotel.Id, Is.EqualTo(expectedHotelId));
        }
    }
}