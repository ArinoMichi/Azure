using AereopuertosNugetAlexia.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AereopuertosNugetAlexia.Services
{
    public class ServicesAerolinea
    {
        public async Task<AirportsList> GetAirports()
        {
            WebClient client = new WebClient();
            client.Headers["content-type"] = "application/json";
            string url = "https://services.odata.org/V4/(S(2esholowikwyef30ogqjzbvf))/TripPinServiceRW/Airports";
            string dataJson = await client.DownloadStringTaskAsync(url);
            AirportsList airports =
                JsonConvert.DeserializeObject<AirportsList>(dataJson);
            return airports;
        }
        


    }
}
