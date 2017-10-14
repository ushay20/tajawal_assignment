using Hotel.Search.Application.Services;
using Hotel.Search.Application.CustomClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Hotel_Search.Controllers
{
    public class HotelsController : ApiController
    {
        // GET api/hotels

        public IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> GetAllHotels()
        {
            return HotelServices.Instance.GetHotels();
        }

        [Route("api/hotels/name/{name}/sort/{sort}")]
        public IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> GetHotelByName(string name, string sort)
        {
            var data = HotelServices.Instance.GetHotels(name);
            return sort == "name" ? data.OrderBy(a => a.name) : data.OrderBy(a => a.price);
        }

        [Route("api/hotels/destination/{dest}/sort/{sort}")]
        public IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> GetHotelByDest(string dest, string sort)
        {
            var data = HotelServices.Instance.GetHotels("", dest);
            return sort == "name" ? data.OrderBy(a => a.name) : data.OrderBy(a => a.price);
        }
        
        [Route("api/hotels/price-range/{prange}/sort/{sort}")]
        public IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> GetHotelByPrice(string prange, string sort)
        {
            var data = HotelServices.Instance.GetHotels("", "", prange);
            return sort == "name" ? data.OrderBy(a => a.name) : data.OrderBy(a => a.price);
        }

        [Route("api/hotels/date-range/{drange}/sort/{sort}")]
        public IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> GetHotelByDate(string drange, string sort)
        {
            var data = HotelServices.Instance.GetHotels("", "", "", drange);
            return sort == "name" ? data.OrderBy(a => a.name) : data.OrderBy(a => a.price);
        }
    }
}
