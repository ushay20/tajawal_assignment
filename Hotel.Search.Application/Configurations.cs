using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Search.Application
{
    public class Configurations
    {
        public static string API_URL
        {
            get { return ConfigurationManager.AppSettings["api_url"]; }
        }
    }
}
