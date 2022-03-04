using NUnit.Framework;
using HolidaySearcher.Search;

namespace HolidaySearcher.Search.Tests
{
    public class Tests
    {
        [Test]
        [TestCase("MAN", "AGP", "2023-07-01", 7, 2, 9)]
        [TestCase("ANY LONDON", "PMI", "2023-06-15", 10, 6, 5)]
        [TestCase("ANYWHERE", "LPA", "2022-11-10", 14, 7, 6)]
        public void GivenSampleTestCases_WhenSearchIsCalled_ThenTheBestHolidayIsReturned(string depart, string destination, string departureDate, int duration, int expectedFlightId, int expectedHotelId)
        {
            // Given
            ISearch holidaySearch = new Search();

            // When
            var bestHoliday = holidaySearch.SearchHoliday(depart, destination,  departureDate, duration);

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