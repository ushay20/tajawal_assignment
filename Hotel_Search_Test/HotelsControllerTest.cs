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
        public void TestGetHotelByNameSortByName()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByName("media one hotel", "name").Data;

            Assert.Equal("media one hotel", result.ToList()[0].name.ToLower());

            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> noresult = hotelsController.GetHotelByName("no result", "name").Data;
            Assert.True(noresult == null);

        }

        [Fact]
        public void TestGetHotelByNameSortByPrice()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByName("media one hotel", "price").Data;

            Assert.Equal("media one hotel", result.ToList()[0].name.ToLower());

            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> noresult = hotelsController.GetHotelByName("no result", "price").Data;
            Assert.True(noresult == null);

        }

        [Fact]
        public void TestGetHotelByDestSortByName()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByDest("dubai", "name").Data;

            Assert.Equal("dubai", result.ToList()[0].city);

            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> noresult = hotelsController.GetHotelByDest("no result", "name").Data;
            Assert.True(noresult == null);

        }

        [Fact]
        public void TestGetHotelByDestSortByPrice()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByDest("dubai", "price").Data;

            Assert.Equal("dubai", result.ToList()[0].city);

            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> noresult = hotelsController.GetHotelByDest("no result", "price").Data;
            Assert.True(noresult == null);

        }

        [Fact]
        public void TestGetHotelByPriceSortByName()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByPrice("80:100", "name").Data;
            
            Assert.True(result.ToList()[0].price >= 80 && result.ToList()[0].price <= 100);

            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> noresult = hotelsController.GetHotelByPrice("0-0", "name").Data;
            Assert.True(noresult == null);
        }

        [Fact]
        public void TestGetHotelByPriceSortByPrice()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByPrice("80:100", "price").Data;

            Assert.True(result.ToList()[0].price >= 80 && result.ToList()[0].price <= 100);

            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> noresult = hotelsController.GetHotelByPrice("0-0", "price").Data;
            Assert.True(noresult == null);
        }

        [Fact]
        public void TestGetHotelByDateSortByName()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByDate("10-10-2020:15-10-2020", "name").Data;

            Assert.Equal("Concorde Hotel", result.ToList()[0].name);

            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> noresult = hotelsController.GetHotelByDate("10-100-2020:15-100-2020", "name").Data;
            Assert.True(noresult == null);

        }

        [Fact]
        public void TestGetHotelByDateSortByPrice()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByDate("10-10-2020:15-10-2020", "price").Data;

            Assert.Equal("Concorde Hotel", result.ToList()[0].name);

            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> noresult = hotelsController.GetHotelByDate("10-100-2020:15-100-2020", "price").Data;
            Assert.True(noresult == null);

        }
    }
}
