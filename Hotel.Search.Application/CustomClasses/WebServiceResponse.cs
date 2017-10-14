using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Search.Application.CustomClasses
{
    public class WebServiceResponse
    {
        public IEnumerable<Hotel> Data { get; set; }
        public int Status { get; set; }
        public string ErrorMessage { get; set; }
    }
}
