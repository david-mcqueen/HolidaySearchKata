using HolidaySearcher.Repository.Components;
using NUnit.Framework;

namespace HolidaySearcher.Repository.Tests
{
    public class Tests
    {
        [Test]
        public void GivenAFlightRepository_WhenGetAvailableComponentIsCalled_ThenDataIsReturned()
        {
            // Given
            var repo = new Repository<Flight>();

            // When
            var component = repo.GetAvailableComponent();

            // Then
            Assert.That(component, Is.Not.Null);
            Assert.That(component.Id, Is.EqualTo(1));
        }

        [Test]
        public void GivenAHotelRepository_WhenGetAvailableComponentIsCalled_ThenDataIsReturned()
        {
            // Given
            var repo = new Repository<Hotel>();

            // When
            var component = repo.GetAvailableComponent();

            // Then
            Assert.That(component, Is.Not.Null);
            Assert.That(component.Id, Is.EqualTo(1));
        }
    }
}