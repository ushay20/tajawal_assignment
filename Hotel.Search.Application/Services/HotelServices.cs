using Hotel.Search.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Search.Application.Services
{
    public class HotelServices
    {

        private static HotelServices instance = null;

        private HotelServices()
        {
        }

        public static HotelServices Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HotelServices();
                }
                return instance;
            }
        }

        public IEnumerable<CustomClasses.Hotel> GetHotels(string name = "", string dest ="", string priceRange = "", string dateRange = "")
        {
            IEnumerable<CustomClasses.Hotel> retVal = null;
            CustomClasses.WebServiceResponse response = APIHelper.Execute(Configurations.API_URL);
            if (response.Status == (int)StatusEnum.OK)
            {
                retVal = response.Data;

                if (!string.IsNullOrEmpty(name))
                {
                    retVal = retVal.Where(a => a.name.ToUpper() == name.ToUpper());
                }
                if (!string.IsNullOrEmpty(dest))
                {
                    retVal = retVal.Where(a => a.city.ToUpper() == dest.ToUpper());
                }
                if (!string.IsNullOrEmpty(priceRange))
                {
                    retVal = retVal.Where(a => a.price >= double.Parse(priceRange.Split(':')[0]) && a.price <= double.Parse(priceRange.Split(':')[1]));
                }

                if (!string.IsNullOrEmpty(dateRange))
                {
                    if (DateIndexBuilder.dateIndex != null && DateIndexBuilder.dateIndex.Count > 0)
                    {
                        List<int> hotelIds = DateIndexBuilder.dateIndex.Where(a => a.Key >= DateTime.ParseExact(dateRange.Split(':')[0], "dd-MM-yyyy", CultureInfo.InvariantCulture) && a.Key <= DateTime.ParseExact(dateRange.Split(':')[1], "dd-MM-yyyy", CultureInfo.InvariantCulture)).Select(a => a.Value).SelectMany(x => x).Distinct().ToList();
                        retVal = retVal.Where(a => hotelIds.Contains(a.id));
                    }
                }

                if (retVal.ToList().Count == 0)
                {
                    throw new Exception("no records found");
                }
            }

            return retVal;
        }
        
    }
}
