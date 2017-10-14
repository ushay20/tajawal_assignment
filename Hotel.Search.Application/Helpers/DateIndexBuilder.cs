using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Search.Application.Helpers
{
    public class DateIndexBuilder
    {
        public static Dictionary<DateTime, List<int>> dateIndex { get; set; }
        public static void AddIndex(CustomClasses.Hotel hotel)
        {
            foreach(var timing in hotel.availability)
            {
                for (DateTime date = timing.from; date <= timing.to; date = date.AddDays(1))
                {
                    Add(date, hotel.id);
                }
            }
        }

        private static void Add(DateTime date, int id)
        {
            if (dateIndex != null)
            {
                if (dateIndex.ContainsKey(date))
                {
                    dateIndex[date].Add(id);
                }
                else
                {
                    dateIndex.Add(date, new List<int> { id });
                }
            }
            else
            {
                dateIndex = new Dictionary<DateTime, List<int>>();
            }
        }
    }
}
