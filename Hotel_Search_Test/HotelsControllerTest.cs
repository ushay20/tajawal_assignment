﻿using Hotel_Search.Controllers;
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

        }

        [Fact]
        public void TestGetHotelByNameSortByPrice()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByName("media one hotel", "price").Data;

            Assert.Equal("media one hotel", result.ToList()[0].name.ToLower());

        }

        [Fact]
        public void TestGetHotelByDestSortByName()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByDest("dubai", "name").Data;

            Assert.Equal("dubai", result.ToList()[0].city);

        }

        [Fact]
        public void TestGetHotelByDestSortByPrice()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByDest("dubai", "price").Data;

            Assert.Equal("dubai", result.ToList()[0].city);

        }

        [Fact]
        public void TestGetHotelByPriceSortByName()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByPrice("80:100", "name").Data;
            
            Assert.True(result.ToList()[0].price >= 80 && result.ToList()[0].price <= 100);
        }

        [Fact]
        public void TestGetHotelByPriceSortByPrice()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByPrice("80:100", "price").Data;

            Assert.True(result.ToList()[0].price >= 80 && result.ToList()[0].price <= 100);
        }

        [Fact]
        public void TestGetHotelByDateSortByName()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByDate("10-10-2020:15-10-2020", "name").Data;

            Assert.Equal("Concorde Hotel", result.ToList()[0].name);

        }

        [Fact]
        public void TestGetHotelByDateSortByPrice()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByDate("10-10-2020:15-10-2020", "price").Data;

            Assert.Equal("Concorde Hotel", result.ToList()[0].name);

        }
    }
}
