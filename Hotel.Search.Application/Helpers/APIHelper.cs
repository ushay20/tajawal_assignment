using Hotel.Search.Application.CustomClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using Newtonsoft.Json.Converters;

namespace Hotel.Search.Application.Helpers
{
    public class APIHelper
    {
        public static CustomClasses.APIResponse Execute(string url)
        {
            CustomClasses.APIResponse retVal = new CustomClasses.APIResponse();
            retVal.Status = (int)StatusEnum.OK;
            string resStr = string.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            bool arrayStarted = false;
            try
            {
                List<CustomClasses.Hotel> hotels = null;
                int count = 0;
                HttpClient client = new HttpClient();
                using (Stream stream = client.GetStreamAsync(url).Result)
                using (StreamReader sr = new StreamReader(stream))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    CustomClasses.Hotel hotel = null;
                    JsonSerializer serializer = new JsonSerializer
                    {
                        DateFormatString = "dd-MM-yyyy"
                    };

                    while (reader.Read())
                    {
                        if (arrayStarted && reader.TokenType == JsonToken.StartObject)
                        {
                            hotel = serializer.Deserialize<CustomClasses.Hotel>(reader);
                            hotel.id = count;
                            hotels.Add(hotel);
                            DateIndexBuilder.AddIndex(hotel);
                        }
                        else if (reader.TokenType == JsonToken.StartArray)
                        {
                            arrayStarted = true;
                            hotels = new List<CustomClasses.Hotel>();
                        }
                        count++;
                    }
                }

                retVal.Data = hotels;
            }
            catch (WebException ex)
            {
                retVal.Status = (int)StatusEnum.ERROR;
                retVal.ErrorMessage = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
            }

            return retVal;
        }
    }
}
