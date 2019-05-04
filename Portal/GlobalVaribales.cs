using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Portal
{
    public static class GlobalVaribales
    {

        public static HttpClient WebApiClient = new HttpClient();
        public static string portApi = "http://localhost:62196/api/";
      
        static GlobalVaribales()
        { 
            WebApiClient.BaseAddress = new Uri(portApi);
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}