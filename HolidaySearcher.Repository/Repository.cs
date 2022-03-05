using HolidaySearcher.Repository.Components;
using System.Collections.Generic;
using System.Linq;

namespace HolidaySearcher.Repository
{
    public class Repository<T> 
        where T : IHolidayComponent
    {
        private IList<T> _data { get; set; }

        public Repository()
        {
            var fl = new FileLoader<T>();
            _data = fl.Load();
        }

        public IHolidayComponent GetAvailableComponent()
        {
            return _data.First();
        }
    }
}
