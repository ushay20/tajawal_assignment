using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Hotel_Search.Controllers;

namespace Hotel_Search_Testing
{
    [TestFixture]
    public class HotelsControllerTest
    {
        [Test]
        public void TestGetHotelByName()
        {
            HotelsController hotelsController = new HotelsController();
            IEnumerable<Hotel.Search.Application.CustomClasses.Hotel> result = hotelsController.GetHotelByName("media one hotel", "name");

            Assert.AreEqual(result.ToList()[0].name.ToLower(), "media one hotel");

        }
    }
}
