//using Microsoft.AspNetCore.Http;
//using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace CityWeatherApp.Services
{

    public class HttpDataReceiver
    {

        public static async Task<string> GetWebData(string url, string cookie = "")
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                };

                HttpClient httpClient = new HttpClient(handler);
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:68.0) Gecko/20100101 Firefox/68.0");
                httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
                httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
                httpClient.DefaultRequestHeaders.Add("Connection", "keep-alive");
                if (cookie != "")
                    httpClient.DefaultRequestHeaders.Add("Cookie", cookie);
                byte[] dataTAStock_arr = await httpClient.GetByteArrayAsync(url);
                string dataTAStock = Encoding.UTF8.GetString(dataTAStock_arr);
                return dataTAStock;
            }
            catch (Exception e)
            {
                throw new Exception("HttpDataReceiver.GetWebData: " + e.Message);
            }

        }

    }

}


