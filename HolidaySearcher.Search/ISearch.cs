using HolidaySearcher.Repository.Components;
using HolidaySearcher.Search.SearchParameters;
using System.Collections.Generic;

namespace HolidaySearcher.Search
{
    public interface ISearch
    {
        IList<IHolidayComponent> Search(HolidayParameters parameters);
    }
}
