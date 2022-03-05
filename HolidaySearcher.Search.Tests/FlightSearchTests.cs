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


        private static readonly object[] _specificFlightTestData =
        {
            new object[] { "MAN", "TFS", "2023-07-01", new List<int> { 1 } },
            new object[] { "MAN", "AGP", "2023-07-01", new List<int> { 2 } },
            new object[] { "MAN", "PMI", "2023-06-15", new List<int> { 3, 5 } },
            new object[] { "LTN", "PMI", "2023-06-15", new List<int> { 4 } },
            new object[] { "LGW", "PMI", "2023-06-15", new List<int> { 6 } },
            new object[] { "MAN", "LPA", "2022-11-10", new List<int> { 7 } },
            new object[] { "MAN", "LPA", "2023-11-10", new List<int> { 8 } },
            new object[] { "MAN", "AGP", "2023-04-11", new List<int> { 9 } },
            new object[] { "LGW", "AGP", "2023-07-01", new List<int> { 10, 11 } },
            new object[] { "MAN", "AGP", "2023-10-25", new List<int> { 12 } }
        };

        [Test]
        [TestCaseSource("_specificFlightTestData")]
        public void GivenSpecificFlightParameters_WhenSearchIsCalled_ThenAllValidFlightAreReturned(string departure, string destination, string date, List<int> expectedMatchIds)
        {
            // Given
            var fParams = new HolidayParameters
            {
                Departure = departure,
                Destination = destination,
                DepartureDate = DateTime.Parse(date)
            };

            // When
            var flights = _flightSearch.Search(fParams);

            // Then
            Assert.That(flights, Is.Not.Null);
            Assert.That(flights.Count, Is.EqualTo(expectedMatchIds.Count));
            foreach (var id in expectedMatchIds)
            {
                Assert.That(flights.Any(f => f.Id == id), Is.Not.Null);
            }
        }


        private static readonly object[] _regionTestData = {
                new object[] {"ANY", "LPA", "2022-11-10", new List<int> { 7 } },
                new object[] {"ANY LONDON", "PMI", "2023-06-15", new List<int> { 4, 6 } }
            };

        [Test]
        [TestCaseSource("_regionTestData")]
        public void GivenADepartureRegion_WhenSearchIsCalled_ThenAllValidFlightsAreReturned(string departure, string destination, string date, List<int> expectedMatchIds)
        {
            // Given
            var fParams = new HolidayParameters
            {
                Departure = departure,
                Destination = destination,
                DepartureDate = DateTime.Parse(date)
            };

            // When
            var flights = _flightSearch.Search(fParams);

            // Then
            Assert.That(flights, Is.Not.Null);
            Assert.That(flights.Count, Is.EqualTo(expectedMatchIds.Count));
            foreach (var id in expectedMatchIds)
            {
                Assert.That(flights.Any(f => f.Id == id), Is.Not.Null);
            }
        }

        private static readonly object[] _cheapestFlightTestData = {
                new object[] { "MAN", "PMI", "2023-06-15", new List<int> { 5, 3 } },
                new object[] { "LGW", "AGP", "2023-07-01", new List<int> { 11, 10 } },
            };

        [Test]
        [TestCaseSource("_cheapestFlightTestData")]
        public void GivenMultipleFlightMatches_WhenSearchIsCalled_TheCheapestFlightIsReturnedFirst(string departure, string destination, string date, List<int> expectedMatchIds)
        {
            // Given
            var fParams = new HolidayParameters
            {
                Departure = departure,
                Destination = destination,
                DepartureDate = DateTime.Parse(date)
            };

            // When
            var flights = _flightSearch.Search(fParams);

            // Then
            Assert.That(flights, Is.Not.Null);
            Assert.That(flights.Count, Is.EqualTo(expectedMatchIds.Count));

            Assert.That(flights.First().Id, Is.EqualTo(expectedMatchIds.First()));
        }
    }
}
