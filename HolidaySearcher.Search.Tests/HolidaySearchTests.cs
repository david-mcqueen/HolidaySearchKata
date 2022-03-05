using HolidaySearcher.Search.SearchParameters;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidaySearcher.Search.Tests
{
    public class HolidaySearchTests
    {
        private HolidaySearch _holidaySearch { get; set; }

        [SetUp]
        public void Setup()
        {
            _holidaySearch = new HolidaySearch();
        }

        private static readonly object[] _exactHolidayParamsTestData =
        {
            new object[] {
                "MAN",
                "AGP",
                7,
                "2023-07-01",
                new Holiday
                {
                    Flight = new Repository.Components.Flight
                    {
                        Id = 2
                    },
                    Hotel = new Repository.Components.Hotel
                    {
                        Id = 9
                    }
                }
            }
        };

        [Test]
        [TestCaseSource("_exactHolidayParamsTestData")]
        public void GivenExactHolidayParameters_WhenSearchIsCalled_ThenAllValidHolidaysAreReturned(string departure, string destination, int duration, string departureDate, Holiday expectedHoliday)
        {
            // Given
            var hParams = new HolidayParameters
            {
                Departure = departure,
                DepartureDate = DateTime.Parse(departureDate),
                Duration = duration,
                Destination = destination
            };

            // When
            var holidays = _holidaySearch.Search(hParams);

            // Then
            Assert.That(holidays, Is.Not.Null);
            Assert.That(holidays.Flight.Id == expectedHoliday.Flight.Id);
            Assert.That(holidays.Hotel.Id == expectedHoliday.Hotel.Id);
        }
    }
}
