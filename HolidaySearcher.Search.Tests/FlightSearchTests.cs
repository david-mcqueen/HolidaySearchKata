using HolidaySearcher.Search.SearchParameters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidaySearcher.Search.Tests
{
    public class FlightSearchTests
    {
        private FlightSearch _flightSearch { get; set; }

        [SetUp]
        public void Setup()
        {
            _flightSearch = new FlightSearch();
        }

        [Test]
        [TestCase("MAN", "TFS", "2023-07-01", 1)]
        [TestCase("MAN", "AGP", "2023-07-01", 1)]
        [TestCase("MAN", "PMI", "2023-06-15", 2)]
        [TestCase("LTN", "PMI", "2023-06-15", 1)]
        [TestCase("MAN", "PMI", "2023-06-15", 2)]
        [TestCase("LGW", "PMI", "2023-06-15", 1)]
        [TestCase("MAN", "LPA", "2022-11-10", 1)]
        [TestCase("MAN", "LPA", "2023-11-10", 1)]
        [TestCase("MAN", "AGP", "2023-04-11", 1)]
        [TestCase("LGW", "AGP", "2023-07-01", 2)]
        [TestCase("LGW", "AGP", "2023-07-01", 2)]
        [TestCase("MAN", "AGP", "2023-10-25", 1)]
        public void GivenSpecificFlightParameters_WhenSearchIsCalled_ThenAllValidFlightIsReturned(string departure, string destination, string date, int expectedMatches)
        {
            // Given
            var fParams = new FlightParameters
            {
                Departure = departure,
                Destination = destination,
                Date = DateTime.Parse(date)
            };

            // When
            var flights = _flightSearch.Search(fParams);

            // Then
            Assert.That(flights, Is.Not.Null);
            Assert.That(flights.Count, Is.EqualTo(expectedMatches));
        }
    }
}
