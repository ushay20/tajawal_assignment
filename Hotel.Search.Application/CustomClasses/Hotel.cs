using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Search.Application.CustomClasses
{
    public class Hotel
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string city { get; set; }
        public List<Timing> availability { get; set; }
    }

    public class Timing
    {
        public DateTime from { get; set; }
        public DateTime to { get; set; }
    }
}
