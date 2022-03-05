using HolidaySearcher.Repository.Components;

namespace HolidaySearcher.Repository
{
    public interface IRepository
    {
        public IHolidayComponent GetAvailableComponent();
    }
}
