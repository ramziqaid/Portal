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

        static GlobalVaribales()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:62196/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}