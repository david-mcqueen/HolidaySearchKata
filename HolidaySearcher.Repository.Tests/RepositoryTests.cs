using HolidaySearcher.Repository.Components;
using NUnit.Framework;

namespace HolidaySearcher.Repository.Tests
{
    public class Tests
    {
        [Test]
        public void GivenAFlightRepository_WhenGetAvailableComponentIsCalled_ThenAllDataIsReturned()
        {
            // Given
            var repo = new Repository<Flight>();

            // When
            var components = repo.GetAvailableComponent();

            // Then
            Assert.That(components, Is.Not.Null);
            Assert.That(components.Count, Is.EqualTo(12));
        }

        [Test]
        public void GivenAHotelRepository_WhenGetAvailableComponentIsCalled_ThenAllDataIsReturned()
        {
            // Given
            var repo = new Repository<Hotel>();

            // When
            var components = repo.GetAvailableComponent();

            // Then
            Assert.That(components, Is.Not.Null);
            Assert.That(components.Count, Is.EqualTo(13));
        }
    }
}