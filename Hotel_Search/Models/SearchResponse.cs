using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotel_Search.Models
{
    public class SearchResponse
    {
        public string Status { get; set; }
        public IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> Data { get; set; }
        public string ErrorMessage { get; set; }
    }
}