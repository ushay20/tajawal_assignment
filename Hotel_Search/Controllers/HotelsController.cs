using Hotel.Search.Application.Services;
using Hotel.Search.Application.CustomClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hotel_Search.Models;
using Hotel.Search.Application;

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
        public SearchResponse GetHotelByName(string name, string sort)
        {
            SearchResponse response = new SearchResponse();
            response.Status = StatusEnum.OK.ToString();

            try
            {
                var data = HotelServices.Instance.GetHotels(name);
                data = sort == "name" ? data.OrderBy(a => a.name) : data.OrderBy(a => a.price);
                response.Data = data;
            }
            catch(Exception e)
            {
                response.Status = StatusEnum.ERROR.ToString();
                response.ErrorMessage = e.Message;
            }

            return response;
        }

        [Route("api/hotels/destination/{dest}/sort/{sort}")]
        public SearchResponse GetHotelByDest(string dest, string sort)
        {
            SearchResponse response = new SearchResponse();
            response.Status = StatusEnum.OK.ToString();

            try
            {
                var data = HotelServices.Instance.GetHotels("", dest);
                data = sort == "name" ? data.OrderBy(a => a.name) : data.OrderBy(a => a.price);
                response.Data = data;
            }
            catch (Exception e)
            {
                response.Status = StatusEnum.ERROR.ToString();
                response.ErrorMessage = e.Message;
            }

            return response;
        }
        
        [Route("api/hotels/price-range/{prange}/sort/{sort}")]
        public SearchResponse GetHotelByPrice(string prange, string sort)
        {
            SearchResponse response = new SearchResponse();
            response.Status = StatusEnum.OK.ToString();

            try
            {
                var data = HotelServices.Instance.GetHotels("", "", prange);
                data = sort == "name" ? data.OrderBy(a => a.name) : data.OrderBy(a => a.price);
                response.Data = data;
            }
            catch (Exception e)
            {
                response.Status = StatusEnum.ERROR.ToString();
                response.ErrorMessage = e.Message;
            }

            return response;
        }

        [Route("api/hotels/date-range/{drange}/sort/{sort}")]
        public SearchResponse GetHotelByDate(string drange, string sort)
        {
            SearchResponse response = new SearchResponse();
            response.Status = StatusEnum.OK.ToString();

            try
            {
                var data = HotelServices.Instance.GetHotels("", "", "", drange);
                data = sort == "name" ? data.OrderBy(a => a.name) : data.OrderBy(a => a.price);
                response.Data = data;
            }
            catch (Exception e)
            {
                response.Status = StatusEnum.ERROR.ToString();
                response.ErrorMessage = e.Message;
            }

            return response;
        }
    }
}
