using Hotel_Search.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Hotel_Search_Test
{
    public class HotelsControllerTest
    {
        [Fact]
        public void TestGetHotelByName()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByName("media one hotel", "name");

            Assert.Equal("media one hotel", result.ToList()[0].name.ToLower());

        }

        [Fact]
        public void TestGetHotelByDest()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByDest("dubai", "name");

            Assert.Equal("dubai", result.ToList()[0].city);

        }

        [Fact]
        public void GetHotelByPrice()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByPrice("80:100", "name");

            Assert.True(result.ToList()[0].price >= 80 && result.ToList()[0].price <= 100);

        }

        [Fact]
        public void GetHotelByDate()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByDate("10-10-2020:15-10-2020", "name");

            Assert.Equal("Concorde Hotel", result.ToList()[0].name);

        }
    }
}
