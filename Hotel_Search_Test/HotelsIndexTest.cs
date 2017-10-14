using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hotel_Search.Controllers;
using System.Collections.Generic;

namespace Hotel_Search_Test
{
    [TestClass]
    public class HotelsIndexTest
    {
        [TestMethod]
        public void TestGetHotelByName()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByName("media one hotel", "name");
            
            Assert.AreEqual(result.ToList()[0].name.ToLower(), "media one hotel");
            
        }

        [TestMethod]
        public void TestGetHotelByDest()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByDest("dubai", "name");
            
            Assert.AreEqual(result.ToList()[0].city, "dubai");

        }

        [TestMethod]
        public void GetHotelByPrice()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByPrice("80:100", "name");

            Assert.IsTrue(result.ToList()[0].price >= 80 && result.ToList()[0].price <= 100);

        }

        [TestMethod]
        public void GetHotelByDate()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByDate("10-10-2020:15-10-2020", "name");

            Assert.AreEqual(result.ToList()[0].name, "Media One Hotel");

        }
    }
}
