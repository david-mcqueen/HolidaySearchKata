using HolidaySearcher.Repository.Components;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HolidaySearcher.Repository
{
    class FileLoader<T> where T: IHolidayComponent
    {
        public IList<T> Load()
        {
            string fileData;

            if (typeof(T) == typeof(Flight))
            {
                fileData = File.ReadAllText(@"DataSource/flights.json");
            }
            else if (typeof(T) == typeof(Hotel))
            {
                fileData = File.ReadAllText(@"DataSource/hotels.json");
            }
            else
            {
                return null;
            }

            JArray data = JArray.Parse(fileData);
            return data.ToObject<IList<T>>();
        }
    }
}
